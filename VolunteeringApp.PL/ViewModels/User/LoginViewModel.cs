namespace VolunteeringApp.PL.ViewModels.User;

public class LoginViewModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}
