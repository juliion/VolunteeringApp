using System.ComponentModel.DataAnnotations;
using VolunteeringApp.DLL.Enums;
using VolunteeringApp.PL.ViewModels.Enums;

namespace VolunteeringApp.PL.ViewModels.Opportunity;

public class CreateOpportunityViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
    public IFormFile? PictureFile { get; set; }
    public string? PicturePath { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartTime { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndTime { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ApplicationDeadline { get; set; }

    [Required]
    public OpportunityStatus Status { get; set; }

    [Required]
    public string LocationType { get; set; } = null!;
    public string? AddedLocation { get; set; }

    [Url]
    public string? FormForApplicationsPath { get; set; }
    public string? ContactsForApplications { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public OrganizerType OrganizerType { get; set; }
}
