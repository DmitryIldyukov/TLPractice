using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure( EntityTypeBuilder<Composition> builder )
    {
        builder.ToTable( "compositions" )
            .HasKey( c => c.CompositionId );

        builder.Property( c => c.CompositionId )
            .HasComment( "Id композиции" )
            .HasColumnName( "composition_id" )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( c => c.ShortDescription )
            .HasComment( "Краткое описание" )
            .HasColumnName( "short_description" )
            .IsRequired();

        builder.Property( c => c.Name )
            .HasComment( "Название композиции" )
            .HasColumnName( "name" )
            .HasMaxLength( 120 )
            .IsRequired();

        builder.Property( c => c.AuthorId )
            .HasComment( "Id автора" )
            .HasColumnName( "author_id" )
            .IsRequired();

        builder.Property( c => c.HeroesInformation )
            .HasComment( "Информация о героях произведения" )
            .HasColumnName( "heroes_information" )
            .IsRequired();

        builder.HasMany( c => c.Plays )
            .WithOne( p => p.Composition )
            .HasForeignKey( p => p.CompositionId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
