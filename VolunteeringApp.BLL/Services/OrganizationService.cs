using AutoMapper;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.DLL;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.DLL.Enums;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.Common.Exceptions;

namespace VolunteeringApp.BLL.Services;

public class OrganizationService : IOrganizationService
{
    private readonly VolunteeringAppDbContext _context;
    private readonly IMapper _mapper;

    public OrganizationService(VolunteeringAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Add(CreateOrganizationDTO organizationDTO)
    {
        var newOrganization = _mapper.Map<CreateOrganizationDTO, Organization>(organizationDTO);
        newOrganization.Status = Status.Pending;
        newOrganization.CreatedAt = DateTime.Now.ToUniversalTime();
        newOrganization.UpdatedAt = DateTime.Now.ToUniversalTime();

        _context.Organizations.Add(newOrganization);
        await _context.SaveChangesAsync();

        return newOrganization.Id;
    }

    public async Task<OrganizationDTO> Get(Guid id)
    {
        var orgs = await _context.Organizations
                .Include(org => org.User)
                .ToListAsync();
        var org = orgs.FirstOrDefault(o => o.Id == id);
        if (org == null)
        {
            throw new NotFoundException();
        }

        var orgDto = _mapper.Map<Organization, OrganizationDTO>(org);

        return orgDto;
    }

    private async Task<FilteredOrganizationsDTO> ApplyFilters(OrganizationsQueryFilters filters)
    {
        var query = _context.Organizations
            .Include(org => org.User)
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

        var total = await query.CountAsync();
        var take = filters.Take;
        var skip = filters.Skip;

        var orgs = await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        var orgsDTOs = _mapper.Map<List<Organization>, List<OrganizationDTO>>(orgs);


        var filteredOrganizations = new FilteredOrganizationsDTO
        {
            Take = take,
            Skip = skip,
            Total = total,
            Organizations = orgsDTOs
        };

        return filteredOrganizations;
    }

    public async Task<FilteredOrganizationsDTO> GetFiltered(OrganizationsQueryFilters filters)
    {
        var filteredOrganizations = await ApplyFilters(filters);

        return filteredOrganizations;
    }

    public async Task Update(Guid id, UpdateOrganizationDTO organizationDTO)
    {
        var org = await _context.Organizations.FindAsync(id);
        if (org == null)
        {
            throw new NotFoundException();
        }

        org.Name = organizationDTO.Name ?? org.Name;
        org.Email = organizationDTO.Email ?? org.Email;
        org.PhoneNumber = organizationDTO.PhoneNumber ?? org.PhoneNumber;
        org.Description = organizationDTO.Description ?? org.Description;
        org.City = organizationDTO.City ?? org.City;
        org.Address = organizationDTO.Address ?? org.Address;
        org.Status = organizationDTO.Status ?? org.Status;
        org.PicturePath = organizationDTO.PicturePath ?? org.PicturePath;

        org.UpdatedAt = DateTime.Now.ToUniversalTime();

        await _context.SaveChangesAsync();
    }
}
