using VolunteeringApp.BLL.DTOs.User;

namespace VolunteeringApp.BLL.DTOs.Organization;

public class OrganizationDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Description { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool Verified { get; set; }
    public string? PicturePath { get; set; }
    public UserDTO User { get; set; } = null!;
}
