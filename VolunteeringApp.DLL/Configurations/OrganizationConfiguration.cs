using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.DLL.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(org => org.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(org => org.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(org => org.PhoneNumber)
            .HasMaxLength(13);
        builder.Property(org => org.Description)
            .IsRequired();
        builder.Property(org => org.City)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(org => org.Address)
            .IsRequired();
        builder.Property(org => org.Status)
            .IsRequired();
        builder.Property(org => org.CreatedAt)
            .IsRequired();
        builder.Property(org => org.UpdatedAt)
            .IsRequired();
        builder.HasOne(o => o.User)
            .WithMany(u => u.Organizations)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
