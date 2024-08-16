using System.ComponentModel.DataAnnotations;
using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.ViewModels.User;

public class RegistrationViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Surname { get; set; } = null!;

    [Required]
    [EmailAddress(ErrorMessage = "Неправильний формат електронної пошти.")]
    public string Email { get; set; } = null!;

    [Required]
    [Phone(ErrorMessage = "Номер телефону неправильний.")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password", ErrorMessage = "Паролі не збігаються.")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; } = null!;
    public bool IsOrganizationRep { get; set; }
}
