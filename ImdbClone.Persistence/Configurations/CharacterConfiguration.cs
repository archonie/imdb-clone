using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImdbClone.Persistence.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.HasOne(c => c.Film)
            .WithMany(f => f.Characters)
            .HasForeignKey(c => c.FilmId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: specify the behavior on delete

        builder.HasOne(c => c.Actor)
            .WithMany(a => a.Characters)
            .HasForeignKey(c => c.ActorId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}