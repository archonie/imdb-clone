using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImdbClone.Persistence.Configurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Description)
            .HasMaxLength(500);

        builder.Property(f => f.Rate)
            .IsRequired();

        builder.HasMany(f => f.Users)
            .WithMany(u => u.WatchedFilms)
            .UsingEntity<Dictionary<string, object>>(
                "UserFilm",
                j => j.HasOne<ApplicationUser>().WithMany().HasForeignKey("UserId"),
                j => j.HasOne<Film>().WithMany().HasForeignKey("FilmId"));

        builder.HasMany(f => f.Characters)
            .WithOne(c => c.Film)
            .HasForeignKey(c => c.FilmId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: specify the behavior on delete

        builder.HasOne(f => f.Director)
            .WithMany(d => d.Films)
            .HasForeignKey(f => f.DirectorId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}