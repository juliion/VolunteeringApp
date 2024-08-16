using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.DLL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(user => user.Surname)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(u => u.Organizations)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
