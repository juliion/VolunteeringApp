using System.ComponentModel.DataAnnotations;

namespace VolunteeringApp.PL.ViewModels.Organization;

public class CreateOrganizationViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Address { get; set; } = null!;
    public IFormFile? PictureFile { get; set; }
    public string? PicturePath { get; set; }
    public Guid UserId { get; set; }
}
