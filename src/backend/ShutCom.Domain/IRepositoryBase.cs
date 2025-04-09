using System.Linq.Expressions;
using ShutCom.Model;

namespace ShutCom.Domain;

public interface IRepositoryBase<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Retrieves an entity given its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The retrieved entity if found, <c>null</c> otherwise.</returns>
    TEntity? Get(int id);

    /// <summary>
    /// Retrieves all entities available in the database.
    /// </summary>
    /// <returns>A collection of entities.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Retrieves a filtered list of entities based on a predicate.
    /// </summary>
    /// <param name="predicate">The filter condition.</param>
    /// <returns>A collection of entities matching the predicate.</returns>
    IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Saves an entity to the database.
    /// </summary>
    /// <param name="entity">The entity to be saved.</param>
    /// <returns>The saved entity if successful, <c>null</c> otherwise.</returns>
    TEntity? Save(TEntity entity);

    /// <summary>
    /// Saves multiple entities to the database in a transactional manner.
    /// </summary>
    /// <param name="entities">The collection of entities to be saved.</param>
    /// <returns>A collection of saved entities if successful, <c>null</c> otherwise.</returns>
    IEnumerable<TEntity>? SaveMultiple(IEnumerable<TEntity> entities);

    /// <summary>
    /// Attempts to save multiple entities to the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="entities">The collection of entities to be saved.</param>
    /// <returns>An object indicating the successful and failed saves.</returns>
    NonTransactionalResult<TEntity> TrySaveMultiple(IEnumerable<TEntity> entities);

    /// <summary>
    /// Updates an entity in the database.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <returns>The updated entity if successful, <c>null</c> otherwise.</returns>
    TEntity? Update(TEntity entity);

    /// <summary>
    /// Updates multiple entities in the database in a transactional manner.
    /// </summary>
    /// <param name="entities">The collection of entities to be updated.</param>
    /// <returns>A collection of updated entities if successful, <c>null</c> otherwise.</returns>
    IEnumerable<TEntity>? UpdateMultiple(IEnumerable<TEntity> entities);

    /// <summary>
    /// Attempts to update multiple entities in the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="entities">The collection of entities to be updated.</param>
    /// <returns>An object indicating the successful and failed updates.</returns>
    NonTransactionalResult<TEntity> TryUpdateMultiple(IEnumerable<TEntity> entities);

    /// <summary>
    /// Deletes an entity from the database given its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <returns>The deleted entity if found, <c>null</c> otherwise.</returns>
    TEntity? Delete(int id);

    /// <summary>
    /// Deletes multiple entities from the database in a transactional manner.
    /// </summary>
    /// <param name="ids">The collection of unique identifiers for the entities to be deleted.</param>
    /// <returns>A collection of deleted entities if successful, <c>null</c> otherwise.</returns>
    int DeleteMultiple(IEnumerable<int> ids);

    /// <summary>
    /// Attempts to delete multiple entities from the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="ids">The collection of unique identifiers for the entities to be deleted.</param>
    /// <returns>An object indicating the successful and failed deletions.</returns>
    NonTransactionalResult<TEntity> TryDeleteMultiple(IEnumerable<int> ids);

    /// <summary>
    /// Asynchronously retrieves an entity given its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation, containing the retrieved entity if found, <c>null</c> otherwise.</returns>
    Task<TEntity?> GetAsync(int id);

    /// <summary>
    /// Asynchronously saves an entity to the database.
    /// </summary>
    /// <param name="entity">The entity to be saved.</param>
    /// <returns>A task representing the asynchronous operation, containing the saved entity if successful, <c>null</c> otherwise.</returns>
    Task<TEntity?> SaveAsync(TEntity entity);

    /// <summary>
    /// Asynchronously saves multiple entities to the database in a transactional manner.
    /// </summary>
    /// <param name="entities">The collection of entities to be saved.</param>
    /// <returns>A task representing the asynchronous operation, containing a collection of saved entities if successful, <c>null</c> otherwise.</returns>
    Task<IEnumerable<TEntity>?> SaveMultipleAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Asynchronously attempts to save multiple entities to the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="entities">The collection of entities to be saved.</param>
    /// <returns>A task representing the asynchronous operation, containing an object indicating the successful and failed saves.</returns>
    Task<NonTransactionalResult<TEntity>> TrySaveMultipleAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Asynchronously updates an entity in the database.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <returns>A task representing the asynchronous operation, containing the updated entity if successful, <c>null</c> otherwise.</returns>
    Task<TEntity?> UpdateAsync(TEntity entity);

    /// <summary>
    /// Asynchronously updates multiple entities in the database in a transactional manner.
    /// </summary>
    /// <param name="entities">The collection of entities to be updated.</param>
    /// <returns>A task representing the asynchronous operation, containing a collection of updated entities if successful, <c>null</c> otherwise.</returns>
    Task<IEnumerable<TEntity>?> UpdateMultipleAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Asynchronously attempts to update multiple entities in the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="entities">The collection of entities to be updated.</param>
    /// <returns>A task representing the asynchronous operation, containing an object indicating the successful and failed updates.</returns>
    Task<NonTransactionalResult<TEntity>> TryUpdateMultipleAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// Asynchronously deletes an entity from the database given its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, containing the deleted entity if found, <c>null</c> otherwise.</returns>
    Task<TEntity?> DeleteAsync(int id);

    /// <summary>
    /// Asynchronously deletes multiple entities from the database in a transactional manner.
    /// </summary>
    /// <param name="entities">The collection of entities to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, containing a collection of deleted entities if successful, <c>null</c> otherwise.</returns>
    Task<int> DeleteMultipleAsync(IEnumerable<int> ids);

    /// <summary>
    /// Asynchronously attempts to delete multiple entities from the database. Entities that fail will be reported.
    /// </summary>
    /// <param name="ids">The collection of unique identifiers for the entities to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, containing an object indicating the successful and failed deletions.</returns>
    Task<NonTransactionalResult<TEntity>> TryDeleteMultipleAsync(IEnumerable<int> ids);
}