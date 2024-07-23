using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpotlightDbContext : DbContext
{
    public SpotlightDbContext( DbContextOptions<SpotlightDbContext> options ) 
        : base( options )
    { }

    #region DbSets

    #endregion

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );


    }
}
