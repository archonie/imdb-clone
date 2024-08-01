using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImdbClone.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(u => u.WatchedFilms)
            .WithMany(f => f.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserFilm",
                j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId"),
                j => j.HasOne<ApplicationUser>().WithMany().HasForeignKey("UserId"));
    }
}