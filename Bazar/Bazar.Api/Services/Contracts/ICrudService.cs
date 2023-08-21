namespace Bazar.Api.Services.Contracts;

public interface ICrudService<TEntity>
{
    public Task<IEnumerable<TEntity>> GetAll(Guid userId);
    public Task<TEntity?> Get(Guid entityId);
    public Task<TEntity> Add(Guid ownerUserId,TEntity entity);
    public Task<TEntity> Edit(Guid id, TEntity entity);
    public bool Delete(Guid id);
}