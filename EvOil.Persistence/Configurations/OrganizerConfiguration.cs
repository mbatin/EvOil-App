using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvOil.Persistence.Configurations;

internal class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        _ = builder.Property(organizer => organizer.Id).HasMaxLength(100);
        _ = builder.HasIndex(organizer => organizer.Id).IsUnique();

        _ = builder.HasKey(organizer => new { organizer.Id });
    }
}