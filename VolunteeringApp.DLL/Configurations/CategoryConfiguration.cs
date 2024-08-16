using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.DLL.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(category => category.Opportunities)
            .WithOne(o => o.Category)
            .HasForeignKey(o => o.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
