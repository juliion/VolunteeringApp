using Microsoft.AspNetCore.Identity;

namespace VolunteeringApp.DLL.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public ICollection<Organization> Organizations { get; set; } = new List<Organization>();
}
