using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessLayer.Constants;

namespace DataAccessLayer.Configuration;

public class SealingReportConfiguration : IEntityTypeConfiguration<SealingReport>
{
    public void Configure(EntityTypeBuilder<SealingReport> builder)
    {
        builder.ToTable(TableNames.SealingReport);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaperId).IsRequired();

        builder.Property(c => c.CreatedAt).IsRequired();

        builder.Property(c => c.Status).IsRequired();
    }
}
