using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.BLL.DTOs.Organization;
using VolunteeringApp.BLL.DTOs.User;
using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.BLL.DTOs.Opportunity;

public class OpportunityDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? PicturePath { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public OpportunityStatus Status { get; set; }
    public string Location { get; set; } = null!;
    public string? FormForApplicationsPath { get; set; }
    public string? ContactsForApplications { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public CategoryDTO Category { get; set; } = null!;
    public UserDTO? UserOrganizer { get; set; }
    public OrganizationDTO? OrganizationOrganizer { get; set; }
}
