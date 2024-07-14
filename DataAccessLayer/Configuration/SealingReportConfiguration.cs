using DataAccessLayer.Constants;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class SealingReportConfiguration : IEntityTypeConfiguration<SealingReport>
{
    public void Configure(EntityTypeBuilder<SealingReport> builder)
    {
        builder.ToTable(TableNames.SealingReport);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaperId).IsRequired();

        builder
            .Property(c => c.SealingReportStatus)
            .HasConversion(
                v => v.ToString(),
                v => (SealingReportStatus)Enum.Parse(typeof(SealingReportStatus), v)
            )
            .IsRequired();

        builder.Property(c => c.CreatedAt).IsRequired();

        builder.Property(c => c.IsDelete).IsRequired();
    }
}
