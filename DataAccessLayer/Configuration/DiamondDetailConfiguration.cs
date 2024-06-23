using DataAccessLayer.Constants;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class DiamondDetailConfiguration : IEntityTypeConfiguration<DiamondDetail>
{
    public void Configure(EntityTypeBuilder<DiamondDetail> builder)
    {
        builder.ToTable(TableNames.DiamondDetail);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.StaffId).IsRequired();

        builder.Property(c => c.TicketId).IsRequired();

        builder.Property(c => c.Origin).IsRequired();

        builder.Property(c => c.CaratWeight).IsRequired();

        builder
            .Property(c => c.Clarity)
            .HasConversion(v => v.ToString(), v => (Quality)Enum.Parse(typeof(Quality), v))
            .IsRequired();

        builder
            .Property(c => c.Cut)
            .HasConversion(v => v.ToString(), v => (Quality)Enum.Parse(typeof(Quality), v))
            .IsRequired();

        builder
            .Property(c => c.Proportions)
            .HasConversion(v => v.ToString(), v => (Quality)Enum.Parse(typeof(Quality), v))
            .IsRequired();

        builder
            .Property(c => c.Color)
            .HasConversion(
                v => v.ToString(),
                v => (GlowStrength)Enum.Parse(typeof(GlowStrength), v)
            )
            .IsRequired();

        builder
            .Property(c => c.Polish)
            .HasConversion(v => v.ToString(), v => (Quality)Enum.Parse(typeof(Quality), v))
            .IsRequired();

        builder
            .Property(c => c.Symmetry)
            .HasConversion(v => v.ToString(), v => (Quality)Enum.Parse(typeof(Quality), v))
            .IsRequired();

        builder
            .Property(c => c.Fluorescence)
            .HasConversion(
                v => v.ToString(),
                v => (GlowStrength)Enum.Parse(typeof(GlowStrength), v)
            )
            .IsRequired();

        builder.Property(c => c.IsDelete).IsRequired();
    }
}
