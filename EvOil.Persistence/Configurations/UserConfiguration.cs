using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvOil.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.Property(user => user.Username).HasMaxLength(100);
        _ = builder.HasIndex(user => user.Username).IsUnique();
        //_ = builder.Ignore(user => user.Password);
        _ = builder.Property(user => user.Password).HasMaxLength(100);
        _ = builder.HasIndex(user => user.Password).IsUnique();

        _ = builder.HasKey(user => new { user.Username });
    }
}