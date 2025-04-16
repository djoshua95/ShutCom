using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.AppConstants;

namespace MysticMadness.Service.Utils;

public static class PagingHelper
{
    /// <summary>
    /// Applies paging to an IQueryable source.
    /// </summary>
    /// <typeparam name="TEntity">The type of the elements in the source.</typeparam>
    /// <param name="source">The IQueryable source to apply paging to.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="pageNumber">The page number (1-based).</param>
    /// <returns>A List containing the paged results.</returns>
    public static async Task<List<TEntity>> ApplyPagingAsync<TEntity>(IQueryable<TEntity> source, int pageSize, int pageNumber)
    {
        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), Constants.LoggingMessages.ERROR_INVALID_PAGE_SIZE);
        }
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), Constants.LoggingMessages.ERROR_INVALID_PAGE_NUMBER);
        }
        return await source
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
    }
}
