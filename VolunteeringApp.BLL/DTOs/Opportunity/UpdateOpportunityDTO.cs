using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.DTOs.User;
using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.BLL.DTOs.Opportunity;

public class UpdateOpportunityDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PicturePath { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime? ApplicationDeadline { get; set; }
    public OpportunityStatus? Status { get; set; }
    public string? Location { get; set; }
    public string? FormForApplicationsPath { get; set; }
    public string? ContactsForApplications { get; set; }
}
