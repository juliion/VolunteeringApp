namespace VolunteeringApp.DLL.Entities;

public class Organization
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

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
