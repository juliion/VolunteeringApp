using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.ViewModels.User;

public class RegistrationViewModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
    public bool IsOrganizationRep { get; set; }
}
