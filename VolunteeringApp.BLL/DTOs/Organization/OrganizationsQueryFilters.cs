using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.BLL.DTOs.Organization;

public class OrganizationsQueryFilters
{
    public int Take { get; set; } = 10;
    public int Skip { get; set; } = 0;
    public string SortColumn { get; set; } = "CreatedAt";
    public string? Search { get; set; }
    public string Order { get; set; } = "desc";
    public Status? Status { get; set; }
}
