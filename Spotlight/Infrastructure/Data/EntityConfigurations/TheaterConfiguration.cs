using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure( EntityTypeBuilder<Theater> builder )
    {
        builder.ToTable( "theaters" )
            .HasKey( t => t.TheaterId );

        builder.Property( t => t.TheaterId )
            .HasComment( "Id театра" )
            .HasColumnName( "theater_id" )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( t => t.Address )
            .HasComment( "Адрес" )
            .HasColumnName( "address" )
            .HasMaxLength( 255 )
            .IsRequired();

        builder.Property( t => t.Name )
            .HasComment( "Название" )
            .HasColumnName( "name" )
            .HasMaxLength( 150 )
            .IsRequired();

        builder.Property( t => t.FirstOpeningDate )
            .HasComment( "Дата первого открытия" )
            .HasColumnName( "first_opening_date" )
            .IsRequired();

        builder.Property( t => t.Description )
            .HasComment( "Описание" )
            .HasColumnName( "description" )
            .IsRequired();

        builder.Property( t => t.PhoneNumber )
            .HasComment( "Номер для связи" )
            .HasColumnName( "phone_number" )
            .HasMaxLength( 20 )
            .IsRequired();

        builder.HasMany( t => t.Plays )
            .WithOne( p => p.Theater )
            .HasForeignKey( p => p.TheaterId )
            .OnDelete( DeleteBehavior.Cascade );

        builder.HasMany( t => t.WorkingHours )
            .WithOne( wh => wh.Theater )
            .HasForeignKey ( wh => wh.TheaterId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
