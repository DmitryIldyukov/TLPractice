using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure( EntityTypeBuilder<Composition> builder )
    {
        builder.ToTable( "configurations" )
            .HasKey( c => c.CompositionId );

        builder.Property( c => c.CompositionId )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( c => c.Name )
            .HasMaxLength( 120 )
            .IsRequired();

        builder.Property( c => c.HeroesInformation )
            .IsRequired();

        builder.Property( c => c.AuthorId )
            .IsRequired();

        builder.HasMany( c => c.Plays )
            .WithOne( p => p.Composition )
            .HasForeignKey( p => p.CompositionId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
