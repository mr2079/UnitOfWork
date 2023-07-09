using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UnitOfWork.Architecture.Domain.Common;

namespace UnitOfWork.Architecture.Infrastructure.Persistence;

public interface IMainDbContext : IDisposable
{
    EntityEntry Entry(object entry);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
