using UnitOfWork.Architecture.Application.Contracts.Persistence;

namespace UnitOfWork.Architecture.Infrastructure.Persistence;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository BaseRepository();
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
