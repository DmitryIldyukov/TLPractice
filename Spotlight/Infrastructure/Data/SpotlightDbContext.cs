using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpotlightDbContext : DbContext
{
    public SpotlightDbContext( DbContextOptions<SpotlightDbContext> options )
        : base( options )
    { }

    #region DbSets

    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Play> Plays { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Composition> Compositions { get; set; }
    public DbSet<TheaterHours> TheaterHours { get; set; }

    #endregion

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfigurationsFromAssembly( GetType().Assembly );
    }
}
