using System.Linq.Expressions;
using System.Security.Principal;
using UnitOfWork.Architecture.Domain.Common;

namespace UnitOfWork.Architecture.Application.Contracts.Persistence;

public interface IBaseRepository
{
    Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity;

    IQueryable<T> GetQueryable<T>(
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
        ) where T : BaseEntity;

    Task<T?> GetSingleOrDefaultAsync<T>(
            Expression<Func<T, bool>> expression,
            string includeProperties
        ) where T : BaseEntity;

    Task<List<T>> GetAllAsync<T>() where T : BaseEntity;

    Task<List<T>> GetListAsync<T>(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default
    ) where T : class;

    T Add<T>(T entity) where T : BaseEntity;
    void Update<T>(T entity) where T : BaseEntity;
    void UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity;
    void Delete<T>(T entity) where T : BaseEntity;
}
