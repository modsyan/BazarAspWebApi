using System.Linq.Expressions;
using Bazar.Core.Constants;
using Bazar.Core.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Models;
using Bazar.Core.Interfaces;
using Bazar.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bazar.EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T? Get(Guid id, IList<string>? includes = null)
    {
        return _dbContext.Find<T>(id);
    }

    public IEnumerable<T> Get(IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));
        
        return query.ToList();
    }

    public async Task<T?> GetAsync(Guid id, IList<string>? includes = null)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync(IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));
        
        return await query.ToListAsync();
    }

    public T? FindFirst(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        return query.FirstOrDefault(criteria);
    }


    public T FindSingle(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = query.SingleOrDefault(criteria);

        if (result == null)
        {
            throw new ArgumentException("Entity with that criteria not found");
        }

        return result;
    }

    public async Task<T> FindSingleAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = await query.SingleOrDefaultAsync(criteria);

        if (result == null)
        {
            throw new ArgumentException("Entity with that criteria not found");
        }

        return result;
    }

    public async Task<T> FindFirstAsync(Expression<Func<T, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = await query.SingleOrDefaultAsync(criteria);

        if (result == null)
        {
            throw new ArgumentException("Entity with that criteria not found");
        }

        return result;
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
        List<T> createdEntities = new();
        foreach (var entity in entities)
        {
            createdEntities.Append<>(_dbContext.Add(entity));
        }

        return createdEntities;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _dbContext.Set<T>().AddAsync(entity);
        return entityEntry.Entity;
    }

    public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities)
    {
        List<T> createdEntities = new();
        foreach (var entity in entities)
        {
            createdEntities.Append<>(await _dbContext.AddAsync(entity));
        }

        return createdEntities;
    }

    public T Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
    {
        List<T> updatedEntities = new();
        foreach (var entity in entities)
        {
            updatedEntities.Append<>(_dbContext.Set<T>().Update(entity));
        }

        return updatedEntities;
    }

    public IEnumerable<T> UpdateRange(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        var entity = _dbContext.Find<T>(id);
        if (entity == null) return false; // TODO: needing to handle
        _dbContext.Remove<T>(entity);
        return true;
    }

    public bool Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return true;
    }

    public bool Delete(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }


    public bool DeleteRange(IEnumerable<Guid> ids)
    {
        foreach (var id in ids)
        {
        }

        return true;
    }

    public bool DeleteRange(IEnumerable<T> entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRange(Expression<Func<T, bool>> criteria)
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