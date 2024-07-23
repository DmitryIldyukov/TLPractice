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
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( t => t.Name )
            .HasMaxLength( 150 )
            .IsRequired();

        builder.Property( t => t.FirstOpeningDate )
            .IsRequired();

        builder.Property( t => t.Description )
            .IsRequired();

        builder.Property( t => t.PhoneNumber )
            .HasMaxLength( 20 )
            .IsRequired();

        builder.HasMany( t => t.Plays )
            .WithOne( p => p.Theater )
            .HasForeignKey( p => p.TheaterId );
    }
}
