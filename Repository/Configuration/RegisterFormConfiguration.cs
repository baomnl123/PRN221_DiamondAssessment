using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Constants;

namespace Repository.Configuration;

public class RegisterFormConfiguration : IEntityTypeConfiguration<RegisterForm>
{
    public void Configure(EntityTypeBuilder<RegisterForm> builder)
    {
        builder.ToTable(TableNames.RegisterForm);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.StaffId).IsRequired();

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.Description).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder.Property(c => c.Status).IsRequired();

        builder
            .HasMany(c => c.Tickets)
            .WithOne(c => c.RegisterForm)
            .HasForeignKey(c => c.RegisterFormId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
