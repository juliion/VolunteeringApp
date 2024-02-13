using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;
using VolunteeringApp.DLL.Configurations;

namespace VolunteeringApp.DLL;

public class VolunteeringAppDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<Organization> Organizations { get; set; }
    public VolunteeringAppDbContext(DbContextOptions<VolunteeringAppDbContext> opt)
        : base(opt) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
    }
}
