using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Constants;

namespace Repository.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(TableNames.Ticket);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.RegisterFormId).IsRequired();

        builder.Property(c => c.TicketName).IsRequired();

        builder.Property(c => c.Status).IsRequired();

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder
            .HasMany(c => c.DiamondDetails)
            .WithOne(c => c.Ticket)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
