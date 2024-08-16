namespace VolunteeringApp.BLL.DTOs.Organization;

public class FilteredOrganizationsDTO
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<OrganizationDTO> Organizations { get; set; } = new List<OrganizationDTO>();
}
