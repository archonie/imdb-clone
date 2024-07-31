using ImdbClone.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImdbClone.Persistence.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Age)
            .IsRequired();

        builder.HasMany(d => d.Films)
            .WithOne(f => f.Director)
            .HasForeignKey(f => f.DirectorId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}