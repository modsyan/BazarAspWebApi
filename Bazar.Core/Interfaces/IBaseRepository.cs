using System.Linq.Expressions;
using Bazar.Core.Constants;

namespace Bazar.Core.Interfaces;

public interface IBaseRepository<T> where T : class
{
    T? GetById(int id);
    IEnumerable<T?> GetALl();

    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    T? Find(Expression<Func<T?, bool>> criteria, IList<string>? includes = null);
    Task<T?> FindAsync(Expression<Func<T?, bool>> criteria, IList<string>? includes = null);


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

    void Delete(long id);
    void Delete(T entity);
    void Delete(Expression<Func<T, bool>> criteria);

    void DeleteRange(IEnumerable<long> ids);
    void DeleteRange(IEnumerable<T> entity);
    void DeleteRange(Expression<Func<T, bool>> criteria);

    T Attach(T entity);
    IEnumerable<T> AttachRange(IEnumerable<T> entities);

    int Count();
    int Count(Expression<Func<T, bool>> criteria);

    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> criteria);
}