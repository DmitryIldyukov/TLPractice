using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
{
    public void Configure( EntityTypeBuilder<WorkingHours> builder )
    {
        builder.ToTable( "working_hours" )
            .HasKey( wh => wh.WorkingHoursId );

        builder.Property( wh => wh.WorkingHoursId )
            .HasComment( "Id режима работы" )
            .HasColumnName( "working_hours_id" )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property( wh => wh.DayOfWeek )
            .HasComment( "День недели" )
            .HasColumnName( "day_of_week" )
            .IsRequired();

        builder.Property( wh => wh.OpeningTime )
            .HasComment( "Время открытия" )
            .HasColumnName( "opening_time" )
            .IsRequired();

        builder.Property( wh => wh.ClosingTime )
            .HasComment( "Время закрытия" )
            .HasColumnName( "closing_time" )
            .IsRequired();

        builder.Property( wh => wh.TheaterId )
            .HasComment( "Id театра" )
            .HasColumnName( "theater_id" )
            .IsRequired();

        builder.HasOne( wh => wh.Theater )
            .WithMany( t => t.WorkingHours )
            .HasForeignKey( wh => wh.TheaterId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
