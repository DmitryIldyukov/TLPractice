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
            .HasComment( "Id представления" )
            .HasColumnName( "play_id" )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( p => p.Name )
            .HasComment( "Название" )
            .HasColumnName( "name" )
            .HasMaxLength( 150 )
            .IsRequired();

        builder.Property( p => p.StartDate )
            .HasComment( "Дата начала" )
            .HasColumnName( "start_date" )
            .IsRequired();

        builder.Property( p => p.EndDate )
            .HasComment( "Дата завершения" )
            .HasColumnName( "end_date" )
            .IsRequired();

        builder.Property( p => p.TicketPrice )
            .HasComment( "Стоимость билета" )
            .HasColumnName( "ticket_price" )
            .IsRequired();

        builder.Property( p => p.Description )
            .HasComment( "Описание" )
            .HasColumnName( "description" )
            .IsRequired();

        builder.Property( p => p.TheaterId )
            .HasComment( "Id театра" )
            .HasColumnName( "theater_id" )
            .IsRequired();

        builder.Property( p => p.CompositionId )
            .HasComment( "Id композиции" )
            .HasColumnName( "composition_id" )
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
