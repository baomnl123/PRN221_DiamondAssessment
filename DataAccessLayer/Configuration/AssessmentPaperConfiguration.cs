using DataAccessLayer.Constants;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class AssessmentPaperConfiguration : IEntityTypeConfiguration<AssessmentPaper>
{
    public void Configure(EntityTypeBuilder<AssessmentPaper> builder)
    {
        builder.ToTable(TableNames.AssessmentPaper);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaperCode).IsRequired();

        builder.Property(c => c.TicketId).IsRequired();

        builder.Property(c => c.StaffId).IsRequired();

        builder.Property(c => c.CreatedAt).IsRequired();

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

        builder
            .HasOne(c => c.Ticket)
            .WithOne(c => c.AssessmentPaper)
            .HasForeignKey<AssessmentPaper>(c => c.TicketId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.CommitmentForm)
            .WithOne(c => c.AssessmentPaper)
            .HasForeignKey<CommitmentForm>(c => c.PaperId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.SealingReport)
            .WithOne(c => c.AssessmentPaper)
            .HasForeignKey<SealingReport>(c => c.PaperId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
