using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.DLL.Configurations;

public class OpportunityConfiguration : IEntityTypeConfiguration<Opportunity>
{
    public void Configure(EntityTypeBuilder<Opportunity> builder)
    {
        builder.Property(op => op.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(op => op.Description)
            .IsRequired();
        builder.Property(op => op.StartTime)
            .IsRequired();
        builder.Property(op => op.EndTime)
            .IsRequired();
        builder.Property(op => op.ApplicationDeadline)
            .IsRequired();
        builder.Property(op => op.Location)
            .IsRequired();
        builder.Property(op => op.Status)
            .IsRequired();
        builder.Property(op => op.CreatedAt)
            .IsRequired();
        builder.Property(op => op.UpdatedAt)
            .IsRequired();

        builder.HasOne(op => op.UserOrganizer)
            .WithMany(u => u.Opportunities)
            .HasForeignKey(op => op.UserOrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(op => op.OrganizationOrganizer)
            .WithMany(org => org.Opportunities)
            .HasForeignKey(op => op.OrganizationOrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(op => op.Category)
            .WithMany(cat => cat.Opportunities)
            .HasForeignKey(op => op.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
