using VolunteeringApp.BLL.DTOs.User;
using VolunteeringApp.DLL.Enums;

namespace VolunteeringApp.BLL.DTOs.Organization;

public class UpdateOrganizationDTO
{
    public string? Name { get; set; } 
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public Status? Status { get; set; }
    public string? PicturePath { get; set; }
}
