using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.Generics;

namespace MysticMadness.Service.Factories.PagedResult;

public interface IPagedResultBuilder<TEntity>
{
    IPagedResultBuilder<TEntity> WithSorting(params OrderByOptions<TEntity>[] keySelectors);
    IMappedPagedResultBuilder<TEntity, TDto> WithMapping<TDto>();
    Task<PagedResult<TEntity>> BuildAsync();
}

public class PagedResultBuilder<TEntity>
(
    IMapper mapper,
    IQueryable<TEntity> source,
    int pageSize,
    int pageNumber
) : IPagedResultBuilder<TEntity>
{
    private IQueryable<TEntity> _query = source;
    public IPagedResultBuilder<TEntity> WithSorting(params OrderByOptions<TEntity>[] keySelectors)
    {
        if (keySelectors.Any())
        {
            var currentQuery = keySelectors.First().Descending
                ? _query.OrderByDescending(keySelectors.First().Selector)
                : _query.OrderBy(keySelectors.First().Selector);
            foreach (var keySelector in keySelectors[1..])
            {
                currentQuery = keySelector.Descending
                    ? currentQuery.ThenByDescending(keySelector.Selector)
                    : currentQuery.ThenBy(keySelector.Selector);
            }
            _query = currentQuery;
        }
        return this;
    }
    public IMappedPagedResultBuilder<TEntity, TDto> WithMapping<TDto>()
    {
        return new MappedPagedResultBuilder<TEntity, TDto>(mapper, _query, pageSize, pageNumber);
    }

    public async Task<PagedResult<TEntity>> BuildAsync()
    {
        PagedResult<TEntity> result = new() { TotalItems = await _query.CountAsync(), PageSize = pageSize, PageNumber = pageNumber };
        result.Items = await _query
            .Skip(result.PageSize * (result.PageNumber - 1))
            .Take(result.PageSize)
            .ToListAsync();
        return result;
    }
}