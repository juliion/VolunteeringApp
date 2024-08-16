using VolunteeringApp.BLL.DTOs.Organization;

namespace VolunteeringApp.PL.ViewModels.Organization;

public class FilteredOrganizationsViewModel
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<OrganizationViewModel> Organizations { get; set; } = new List<OrganizationViewModel>();
}
