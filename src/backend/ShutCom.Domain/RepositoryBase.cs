using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShutCom.Domain.Enums;
using ShutCom.Model;

namespace ShutCom.Domain;

public class RepositoryBase<TEntity>(DbContext dbContext) : IRepositoryBase<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public TEntity? Delete(int id)
    {
        TEntity? entity = Get(id);
        if (entity is null)
        {
            return null;
        }
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity?> DeleteAsync(int id)
    {
        TEntity? entity = Get(id);
        if (entity is null)
        {
            return null;
        }
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public int DeleteMultiple(IEnumerable<int> ids)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        int deletedRows = _dbSet
            .Where(e => ids.Contains(e.Id))
            .ExecuteDelete();
        _dbContext.SaveChanges();
        transaction.Commit();
        return deletedRows;
    }

    public async Task<int> DeleteMultipleAsync(IEnumerable<int> ids)
    {
        await using IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
        int deletedRows = await _dbSet
            .Where(e => ids.Contains(e.Id))
            .ExecuteDeleteAsync();
        _dbContext.SaveChanges();
        transaction.Commit();
        return deletedRows;
    }

    public TEntity? Get(int id)
    {
        return _dbSet.Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
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
        _dbSet.AddRange(entities);
        _dbContext.SaveChanges();
        return entities;
    }

    public async Task<IEnumerable<TEntity>?> SaveMultipleAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
        return entities;
    }

    public NonTransactionalResult<TEntity> TryDeleteMultiple(IEnumerable<int> ids)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Delete };
        IQueryable<TEntity> entities = _dbSet
            .Where(e => ids.Contains(e.Id));
        foreach (TEntity entity in entities)
        {
            try
            {
                _dbSet.Remove(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        _dbContext.SaveChanges();
        return result;
    }

    public async Task<NonTransactionalResult<TEntity>> TryDeleteMultipleAsync(IEnumerable<int> ids)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Delete };
        IQueryable<TEntity> entities = _dbSet
            .Where(e => ids.Contains(e.Id));
        foreach (TEntity entity in entities)
        {
            try
            {
                _dbSet.Remove(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        await _dbContext.SaveChangesAsync();
        return result;
    }

    public NonTransactionalResult<TEntity> TrySaveMultiple(IEnumerable<TEntity> entities)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Save };
        foreach (var entity in entities)
        {
            try
            {
                _dbSet.Add(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        _dbContext.SaveChanges();
        return result;
    }

    public async Task<NonTransactionalResult<TEntity>> TrySaveMultipleAsync(IEnumerable<TEntity> entities)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Save };
        foreach (var entity in entities)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        await _dbContext.SaveChangesAsync();
        return result;
    }

    public NonTransactionalResult<TEntity> TryUpdateMultiple(IEnumerable<TEntity> entities)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Update };
        foreach (var entity in entities)
        {
            try
            {
                _dbSet.Update(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        _dbContext.SaveChanges();
        return result;
    }

    public async Task<NonTransactionalResult<TEntity>> TryUpdateMultipleAsync(IEnumerable<TEntity> entities)
    {
        NonTransactionalResult<TEntity> result = new() { TypeOfOperation = TypeOfOperation.Update };
        foreach (var entity in entities)
        {
            try
            {
                _dbSet.Update(entity);
                result.SuccessfulResultsAfterOperation.Add(entity);
            }
            catch
            {
                result.FailedResultsAfterOperation.Add(entity);
            }
        }
        await _dbContext.SaveChangesAsync();
        return result;
    }

    public TEntity? Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<TEntity>? UpdateMultiple(IEnumerable<TEntity> entities)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        _dbSet.UpdateRange(entities);
        _dbContext.SaveChanges();
        transaction.Commit();
        return entities;
    }

    public async Task<IEnumerable<TEntity>?> UpdateMultipleAsync(IEnumerable<TEntity> entities)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        _dbSet.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
        return entities;
    }
}