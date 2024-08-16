using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.DLL.Entities;

public class Opportunity
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

    public Guid CategoryId { get; set; }
    public Guid? UserOrganizerId { get; set; } 
    public Guid? OrganizationOrganizerId { get; set; }
    public Category Category { get; set; } = null!;
    public User? UserOrganizer { get; set; }
    public Organization? OrganizationOrganizer { get; set; }
}
