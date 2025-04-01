using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ShutCom.Domain;

public class RepositoryBase<TEntity>(DbContext dbContext) : IRepositoryBase<TEntity>
    where TEntity : class, new()
{
    private readonly DbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public TEntity? Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity>? DeleteMultiple(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>?> DeleteMultipleAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public TEntity? Get(int id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public TEntity? Save(TEntity entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity?> SaveAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<TEntity>? SaveMultiple(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>?> SaveMultipleAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public NonTransactionalResult<TEntity> TryDeleteMultiple(IEnumerable<int> ids)
    {
        throw new NotImplementedException();
    }

    public Task<NonTransactionalResult<TEntity>> TryDeleteMultipleAsync(IEnumerable<int> ids)
    {
        throw new NotImplementedException();
    }

    public NonTransactionalResult<TEntity> TrySaveMultiple(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<NonTransactionalResult<TEntity>> TrySaveMultipleAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public NonTransactionalResult<TEntity> TryUpdateMultiple(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<NonTransactionalResult<TEntity>> TryUpdateMultipleAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public TEntity? Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity>? UpdateMultiple(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>?> UpdateMultipleAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}