using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessLayer.Constants;

namespace DataAccessLayer.Configuration;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable(TableNames.Staff);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();

        builder.Property(c => c.Role).IsRequired();

        builder
            .HasMany(c => c.AssessmentPapers)
            .WithOne(c => c.Staff)
            .HasForeignKey(c => c.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(c => c.RegisterForms)
            .WithOne(c => c.Staff)
            .HasForeignKey(c => c.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(c => c.DiamondDetails)
            .WithOne(c => c.Staff)
            .HasForeignKey(c => c.StaffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
