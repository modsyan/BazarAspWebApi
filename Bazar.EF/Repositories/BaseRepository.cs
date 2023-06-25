using System.Linq.Expressions;
using Bazar.Core.Constants;
using Bazar.Core.Models;
using Bazar.Core.Interfaces;
using Bazar.EF.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bazar.EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T? GetById(string id)
    {
        return _dbContext.Find<T>(id);
    }

    public IEnumerable<T?> GetALl()
    {
        return _dbContext.Set<T>().ToList();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public T? Find(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        return query.FirstOrDefault(criteria);
    }

    public async Task<T?> FindAsync(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        return await query.FirstOrDefaultAsync(criteria);
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query.Where(criteria).ToList();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
        Expression<Func<T, object>>? orderBy,
        string orderByDirection = OrderBy.Ascending)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQuery, include)
            => currentQuery.Include(include));

        return await query.Where(criteria).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
        Expression<Func<T, object>>? orderBy,
        string orderByDirection = OrderBy.Ascending)
    {
        throw new NotImplementedException();
    }

    public T Create(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> CreateRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<T> CreateAsync(T entity)
    {
        try
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        // todo: handle updating here
        _dbContext.Set<T>().Update(entity);
        _dbContext.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<T> UpdateRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> UpdateRange(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        _dbContext.Set<T>().Find(id);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChangesAsync();
    }

    public void Delete(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<long> ids)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public T Attach(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> AttachRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        return _dbContext.Set<T>().Count();
    }

    public int Count(Expression<Func<T, bool>> criteria)
    {
        return _dbContext.Set<T>().Where(criteria).Count();
    }

    public async Task<int> CountAsync()
    {
        return await _dbContext.Set<T>().CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
    {
        return await _dbContext.Set<T>().Where(criteria).CountAsync();
    }
}