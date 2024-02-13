using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.DLL.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(user => user.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(user => user.PhoneNumber)
            .HasMaxLength(13);
        builder.Property(user => user.Description)
            .IsRequired();
        builder.Property(user => user.City)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(user => user.Address)
            .IsRequired();
        builder.Property(user => user.Verified)
            .IsRequired();

        builder.HasOne(o => o.User)
            .WithMany(u => u.Organizations)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
