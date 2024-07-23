using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure( EntityTypeBuilder<Author> builder )
    {
        builder.ToTable( "authors" )
            .HasKey( c => c.AuthorId );

        builder.Property( c => c.AuthorId )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( c => c.Name )
            .HasMaxLength( 120 )
            .IsRequired();

        builder.Property( c => c.Birthday )
            .IsRequired();

        builder.HasMany( c => c.Compositions )
            .WithOne( c => c.Author )
            .HasForeignKey( c => c.AuthorId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
