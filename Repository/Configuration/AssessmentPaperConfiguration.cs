using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Constants;

namespace Repository.Configuration;

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

        builder.Property(c => c.Measurement).IsRequired();

        builder.Property(c => c.CaratWeight).IsRequired();

        builder.Property(c => c.Clarity).IsRequired();

        builder.Property(c => c.Cut).IsRequired();

        builder.Property(c => c.Proportions).IsRequired();

        builder.Property(c => c.Color).IsRequired();

        builder.Property(c => c.Polish).IsRequired();

        builder.Property(c => c.Symmetry).IsRequired();

        builder.Property(c => c.Fluorescence).IsRequired();

        builder.Property(c => c.Status).IsRequired();

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
