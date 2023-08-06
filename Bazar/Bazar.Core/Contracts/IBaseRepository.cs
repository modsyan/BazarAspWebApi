using System.Linq.Expressions;
using Bazar.Core.Constants;

namespace Bazar.Core.Contracts;

public interface IBaseRepository<T> where T : class
{
    T? Get(Guid id, IList<string>? includes = null);
    IEnumerable<T> Get(IList<string>? includes = null);
    Task<T?> GetAsync(Guid id, IList<string>? includes = null);
    Task<IEnumerable<T>> GetAsync(IList<string>? includes = null);

    T? FindFirst(Expression<Func<T?, bool>> criteria, IList<string>? includes = null);
    T? FindSingle(Expression<Func<T?, bool>> criteria, IList<string>? includes = null);
    Task<T> FindSingleAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null);

    Task<T> FindFirstAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null);

    IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, IList<string>? includes = null);
    IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip);

    IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
        Expression<Func<T, object>>? orderBy, string orderByDirection = OrderBy.Ascending);

    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip);

    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
        Expression<Func<T, object>>? orderBy, string orderByDirection = OrderBy.Ascending);


    T Create(T entity);
    IEnumerable<T> CreateRange(IEnumerable<T> entities);

    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities);

    T Update(T entity);
    IEnumerable<T> UpdateRange(IEnumerable<T> entity);
    IEnumerable<T> UpdateRange(Expression<Func<T, bool>> criteria);

    bool Delete(Guid id);
    bool Delete(T entity);
    bool Delete(Expression<Func<T, bool>> criteria);

    bool DeleteRange(IEnumerable<Guid> ids);
    bool DeleteRange(IEnumerable<T> entity);
    bool DeleteRange(Expression<Func<T, bool>> criteria);

    T Attach(T entity);
    IEnumerable<T> AttachRange(IEnumerable<T> entities);

    int Count();
    int Count(Expression<Func<T, bool>> criteria);

    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> criteria);
}