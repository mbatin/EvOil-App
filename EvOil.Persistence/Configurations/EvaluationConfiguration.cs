using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvOil.Persistence.Configurations;

internal class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
{
    public void Configure(EntityTypeBuilder<Evaluation> builder)
    {
        _ = builder.Property(evaluation => evaluation.Id).HasMaxLength(100);
        _ = builder.HasIndex(evaluation => evaluation.Id).IsUnique();

        _ = builder.HasKey(evaluation => new { evaluation.Id });
    }
}