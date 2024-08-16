using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.Common.Exceptions;
using VolunteeringApp.BLL.DTOs.Opportunity;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.BLL.Services;

public class OpportunityService : IOpportunityService
{
    private readonly VolunteeringAppDbContext _context;
    private readonly IMapper _mapper;
    public OpportunityService(VolunteeringAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Add(CreateOpportunityDTO opportunityDTO)
    {
        var newOpportunity = _mapper.Map<CreateOpportunityDTO, Opportunity>(opportunityDTO);
        newOpportunity.Status = OpportunityStatus.Pending;
        newOpportunity.CreatedAt = DateTime.Now.ToUniversalTime();
        newOpportunity.UpdatedAt = DateTime.Now.ToUniversalTime();
        newOpportunity.StartTime = newOpportunity.StartTime.ToUniversalTime();
        newOpportunity.EndTime = newOpportunity.EndTime.ToUniversalTime();
        newOpportunity.ApplicationDeadline = newOpportunity.ApplicationDeadline.ToUniversalTime();
        
        _context.Opportunities.Add(newOpportunity);
        await _context.SaveChangesAsync();

        return newOpportunity.Id;
    }
    public async Task<OpportunityDTO> Get(Guid id)
    {
        var opportunities = await _context.Opportunities
                .Include(org => org.Category)
                .Include(org => org.UserOrganizer)
                .Include(org => org.OrganizationOrganizer)
                    .ThenInclude(org => org != null ? org.User : null)
                .ToListAsync();
        var opportunity = opportunities.FirstOrDefault(o => o.Id == id);
        if (opportunity == null)
        {
            throw new NotFoundException();
        }

        var opportunityDto = _mapper.Map<Opportunity, OpportunityDTO>(opportunity);

        return opportunityDto;
    }
    private async Task<FilteredOpportunitiesDTO> ApplyFilters(OpportunitiesQueryFilters filters)
    {
        var query = _context.Opportunities
            .Include(org => org.Category)
            .Include(org => org.UserOrganizer)
            .Include(org => org.OrganizationOrganizer)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.SortColumn) && !string.IsNullOrWhiteSpace(filters.Order))
        {
            if (filters.Order == "asc")
            {
                query = query.OrderBy(e => EF.Property<object>(e, filters.SortColumn));
            }
            else if (filters.Order == "desc")
            {
                query = query.OrderByDescending(e => EF.Property<object>(e, filters.SortColumn));
            }
        }

        if (filters.Status != null)
        {
            query = query.Where(t => t.Status == filters.Status);
        }

        if (filters.Search != null)
        {
            query = query.Where(t => t.Name.Contains(filters.Search));
        }

        if (!string.IsNullOrEmpty(filters.Category))
        {
            query = query.Where(t => t.Category.Name == filters.Category);
        }

        if (!string.IsNullOrEmpty(filters.Location))
        {
            query = query.Where(t => t.Location == filters.Location);
        }

        var total = await query.CountAsync();
        var take = filters.Take;
        var skip = filters.Skip;

        var opportunities = await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        var opportunitiesDTOs = _mapper.Map<List<Opportunity>, List<OpportunityDTO>>(opportunities);


        var filteredOrganizations = new FilteredOpportunitiesDTO
        {
            Take = take,
            Skip = skip,
            Total = total,
            Opportunities = opportunitiesDTOs
        };

        return filteredOrganizations;
    }
    public async Task<FilteredOpportunitiesDTO> GetFiltered(OpportunitiesQueryFilters filters)
    {
        var filteredOpportunities = await ApplyFilters(filters);

        return filteredOpportunities;
    }
    public async Task Update(Guid id, UpdateOpportunityDTO opportunityDTO)
    {
        var opportunity = await _context.Opportunities.FindAsync(id);
        if (opportunity == null)
        {
            throw new NotFoundException();
        }

        opportunity.Name = opportunityDTO.Name ?? opportunity.Name;
        opportunity.Description = opportunityDTO.Description ?? opportunity.Description;
        opportunity.Status = opportunityDTO.Status ?? opportunity.Status;
        opportunity.PicturePath = opportunityDTO.PicturePath ?? opportunity.PicturePath;
        opportunity.StartTime = opportunityDTO.StartTime ?? opportunity.StartTime;
        opportunity.EndTime = opportunityDTO.EndTime ?? opportunity.EndTime;
        opportunity.ApplicationDeadline = opportunityDTO.ApplicationDeadline ?? opportunity.ApplicationDeadline;
        opportunity.Location = opportunityDTO.Location ?? opportunity.Location;
        opportunity.FormForApplicationsPath = opportunityDTO.FormForApplicationsPath ?? opportunity.FormForApplicationsPath;
        opportunity.ContactsForApplications = opportunityDTO.ContactsForApplications ?? opportunity.ContactsForApplications;

        opportunity.UpdatedAt = DateTime.Now.ToUniversalTime();
       
        await _context.SaveChangesAsync();
    }
}
