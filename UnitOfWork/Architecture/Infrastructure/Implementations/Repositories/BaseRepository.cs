using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitOfWork.Architecture.Application.Contracts.Persistence;
using UnitOfWork.Architecture.Domain.Common;
using UnitOfWork.Architecture.Infrastructure.Persistence;

namespace UnitOfWork.Architecture.Infrastructure.Implementations.Repositories;

public class BaseRepository : IBaseRepository
{
    private readonly IMainDbContext _dbContext;

    public BaseRepository(IMainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetQueryable<T>(
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
        ) where T : BaseEntity
    {
        var query = _dbContext.Set<T>().Where(expression);
        return orderBy != null ? orderBy(query) : query;
    }

    public async Task<T?> GetSingleOrDefaultAsync<T>(
            Expression<Func<T, bool>> expression,
            string includeProperties
        ) where T : BaseEntity
    {
        var query = _dbContext.Set<T>().AsQueryable();

        var includes = includeProperties.Split(new[] { ',' },
            StringSplitOptions.RemoveEmptyEntries);

        query = includes.Aggregate(query, (current, includeProperty) =>
            current.Include(includeProperty));

        return await query.SingleOrDefaultAsync(expression);
    }

    public async Task<List<T>> GetAllAsync<T>() where T : BaseEntity
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public Task<List<T>> GetListAsync<T>(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default
    ) where T : class
    {
        var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();

        return orderBy != null
            ? orderBy(query).ToListAsync()
            : query.ToListAsync();
    }

    public T Add<T>(T entity) where T : BaseEntity
    {
        return _dbContext.Set<T>().Add(entity).Entity;
    }

    public void Update<T>(T entity) where T : BaseEntity
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public void Delete<T>(T entity) where T : BaseEntity
    {
        _dbContext.Set<T>().Remove(entity);
    }
}
