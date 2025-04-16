using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.Generics;

namespace MysticMadness.Service.Factories.PagedResult;

public interface IMappedPagedResultBuilder<TEntity, TDto>
{
    IMappedPagedResultBuilder<TEntity, TDto> WithSorting(params OrderByOptions<TEntity>[] keySelectors);
    Task<PagedResult<TDto>> BuildAsync();
}

public class MappedPagedResultBuilder<TEntity, TDto>
(
    IMapper mapper,
    IQueryable<TEntity> source,
    int pageSize,
    int pageNumber
) : IMappedPagedResultBuilder<TEntity, TDto>
{
    private IQueryable<TEntity> _query = source;

    public IMappedPagedResultBuilder<TEntity, TDto> WithSorting(params OrderByOptions<TEntity>[] keySelectors)
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

    public async Task<PagedResult<TDto>> BuildAsync()
    {
        PagedResult<TDto> result = new() { TotalItems = await _query.CountAsync(), PageSize = pageSize, PageNumber = pageNumber };
        var items = await _query
            .Skip(result.PageSize * (result.PageNumber - 1))
            .Take(result.PageSize)
            .ToListAsync();
        result.Items = mapper.Map<List<TDto>>(items);
        return result;
    }
}