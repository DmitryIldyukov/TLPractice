using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class PlayConfiguration : IEntityTypeConfiguration<Play>
{
    public void Configure( EntityTypeBuilder<Play> builder )
    {
        builder.ToTable( "plays" )
            .HasKey( p => p.PlayId );

        builder.Property( p => p.PlayId )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( p => p.Name )
            .HasMaxLength( 150 )
            .IsRequired();

        builder.Property( p => p.StartDate )
            .IsRequired();

        builder.Property( p => p.EndDate )
            .IsRequired();

        builder.Property( p => p.TicketPrice )
            .IsRequired();

        builder.Property( p => p.Description )
            .IsRequired();

        builder.Property( p => p.TheaterId )
            .IsRequired();

        builder.Property( p => p.CompositionId )
            .IsRequired();

        builder.HasOne( p => p.Theater )
            .WithMany( t => t.Plays )
            .HasForeignKey( p => p.TheaterId )
            .OnDelete( DeleteBehavior.Cascade );

        builder.HasOne( p => p.Composition )
            .WithMany( c => c.Plays )
            .HasForeignKey( p => p.CompositionId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
