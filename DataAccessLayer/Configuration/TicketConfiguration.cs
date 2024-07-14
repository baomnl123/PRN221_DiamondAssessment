using DataAccessLayer.Constants;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(TableNames.Ticket);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegisterFormId).IsRequired();

        builder.Property(c => c.TicketName).IsRequired();

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder
            .Property(c => c.TicketStatus)
            .HasConversion(
                v => v.ToString(),
                v => (TicketStatus)Enum.Parse(typeof(TicketStatus), v)
            )
            .IsRequired();

        builder.Property(c => c.IsDelete).IsRequired();

        builder
            .HasMany(c => c.DiamondDetails)
            .WithOne(c => c.Ticket)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
