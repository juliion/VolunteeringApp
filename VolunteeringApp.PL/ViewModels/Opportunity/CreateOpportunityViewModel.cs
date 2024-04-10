using VolunteeringApp.DLL.Enums;
using VolunteeringApp.PL.ViewModels.Enums;

namespace VolunteeringApp.PL.ViewModels.Opportunity;

public class CreateOpportunityViewModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile? PictureFile { get; set; }
    public string? PicturePath { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public OpportunityStatus Status { get; set; }
    public string LocationType { get; set; } = null!;
    public string? AddedLocation { get; set; }
    public string? FormForApplicationsPath { get; set; }
    public string? ContactsForApplications { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid CategoryId { get; set; }

    public OrganizerType OrganizerType { get; set; }
}
