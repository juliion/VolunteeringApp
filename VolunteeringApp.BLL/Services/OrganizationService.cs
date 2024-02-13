using AutoMapper;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.DLL;
using VolunteeringApp.BLL.DTOs.Organization;

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
        newOrganization.Verified = false;
        _context.Organizations.Add(newOrganization);
        await _context.SaveChangesAsync();

        return newOrganization.Id;
    }
}
