namespace VolunteeringApp.PL.ViewModels.Organization;

public class CreateOrganizationViewModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Description { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? PicturePath { get; set; }
    public Guid UserId { get; set; }
}
