using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImdbClone.Persistence.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Age)
            .IsRequired();

        builder.HasMany(a => a.Characters)
            .WithOne(c => c.Actor)
            .HasForeignKey(c => c.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}