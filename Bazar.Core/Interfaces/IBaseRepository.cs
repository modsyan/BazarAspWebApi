using System.Linq.Expressions;
using Bazar.Core.Constants;

namespace Bazar.Core.Interfaces;

public interface IBaseRepository<T> where T : class
{
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    IEnumerable<T?> GetALl();
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
    
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entity);
    void UpdateRange(Expression<Func<T,bool>> criteria);
    
    
    void DeleteById(long id);
    void Delete(T entity);
    
    
    void DeleteRangeById(IEnumerable<long> ids);
    void DeleteRange(IEnumerable<T> entity);
    void DeleteRange(Expression<Func<T, bool>> criteria);

    
    int Count();
    int Count(Expression<Func<T,bool>> criteria);
    
    int CountAsync();
    int CountAsync(Expression<Func<T,bool>> criteria);
}
