using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Constants;

namespace Repository.Configuration;

public class DiamondDetailConfiguration : IEntityTypeConfiguration<DiamondDetail>
{
    public void Configure(EntityTypeBuilder<DiamondDetail> builder)
    {
        builder.ToTable(TableNames.DiamondDetail);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.StaffId).IsRequired();

        builder.Property(c => c.TicketId).IsRequired();

        builder.Property(c => c.Origin).IsRequired();

        builder.Property(c => c.Measurement).IsRequired();

        builder.Property(c => c.CaratWeight).IsRequired();

        builder.Property(c => c.Clarity).IsRequired();

        builder.Property(c => c.Cut).IsRequired();

        builder.Property(c => c.Proportions).IsRequired();

        builder.Property(c => c.Color).IsRequired();

        builder.Property(c => c.Polish).IsRequired();

        builder.Property(c => c.Symmetry).IsRequired();

        builder.Property(c => c.Fluorescence).IsRequired();
    }
}
