using Application.Interfaces;

namespace Infrastructure.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly SpotlightDbContext _context;

    public UnitOfWork( SpotlightDbContext context )
    {
        _context = context;
    }

    public Task SaveChangesAsync( CancellationToken cancellationToken = default )
    {
        return _context.SaveChangesAsync( cancellationToken );
    }
}
