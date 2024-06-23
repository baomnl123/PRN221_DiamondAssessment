using DataAccessLayer.Constants;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration;

public class CommitmentFormConfiguration : IEntityTypeConfiguration<CommitmentForm>
{
    public void Configure(EntityTypeBuilder<CommitmentForm> builder)
    {
        builder.ToTable(TableNames.CommitmentForm);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaperId).IsRequired();

        builder.Property(c => c.CreatedAt).IsRequired();

        builder.Property(c => c.IsDelete).IsRequired();
    }
}
