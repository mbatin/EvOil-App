using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvOil.Persistence.Configurations;

internal class OilConfiguration : IEntityTypeConfiguration<Oil>
{
    public void Configure(EntityTypeBuilder<Oil> builder)
    {
        _ = builder.Property(oil => oil.CodeName).HasMaxLength(100);
        _ = builder.HasIndex(oil => oil.CodeName).IsUnique();
        //_ = builder.Ignore(oil => oil.FullName);
        _ = builder.Property(oil => oil.FullName).HasMaxLength(100);
        _ = builder.HasIndex(oil => oil.FullName).IsUnique();

        _ = builder.HasKey(oil => new { oil.CodeName });
    }
}