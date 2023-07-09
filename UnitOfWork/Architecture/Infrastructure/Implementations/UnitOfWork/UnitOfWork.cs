using UnitOfWork.Architecture.Application.Contracts.Persistence;
using UnitOfWork.Architecture.Infrastructure.Implementations.Repositories;
using UnitOfWork.Architecture.Infrastructure.Persistence;

namespace UnitOfWork.Architecture.Infrastructure.Implementations.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private IMainDbContext _dbContext;
    private bool _disposed;

    public UnitOfWork(IMainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IBaseRepository BaseRepository()
    {
        return new BaseRepository(_dbContext);
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();

        _disposed = true;
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}
