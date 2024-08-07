using DataAccessLayer.Constants;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class RegisterFormConfiguration : IEntityTypeConfiguration<RegisterForm>
{
    public void Configure(EntityTypeBuilder<RegisterForm> builder)
    {
        builder.ToTable(TableNames.RegisterForm);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.StaffId).IsRequired(false);

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.Description).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder
            .Property(c => c.RegisterFormStatus)
            .HasConversion(
                v => v.ToString(),
                v => (RegisterFormStatus)Enum.Parse(typeof(RegisterFormStatus), v)
            )
            .IsRequired();

        builder.Property(c => c.IsDelete).IsRequired();

        builder
            .HasMany(c => c.Tickets)
            .WithOne(c => c.RegisterForm)
            .HasForeignKey(c => c.RegisterFormId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
