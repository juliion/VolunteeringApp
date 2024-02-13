using VolunteeringApp.BLL.DTOs.Organization;

namespace VolunteeringApp.BLL.Interfaces;

public interface IOrganizationService
{
    public Task<Guid> Add(CreateOrganizationDTO organizationDTO);
}
