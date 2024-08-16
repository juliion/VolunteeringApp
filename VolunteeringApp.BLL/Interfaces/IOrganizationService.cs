using VolunteeringApp.BLL.DTOs.Organization;

namespace VolunteeringApp.BLL.Interfaces;

public interface IOrganizationService
{
    public Task<Guid> Add(CreateOrganizationDTO organizationDTO);
    public Task<FilteredOrganizationsDTO> GetFiltered(OrganizationsQueryFilters filters);
    public Task<OrganizationDTO> Get(Guid id);
    public Task Update(Guid id, UpdateOrganizationDTO organizationDTO);
}
