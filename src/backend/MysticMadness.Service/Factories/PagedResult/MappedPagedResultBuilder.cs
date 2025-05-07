using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.Generics;
using MysticMadness.Service.Utils;

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
        _query = _query.ApplySorting(keySelectors);
        return this;
    }

    public async Task<PagedResult<TDto>> BuildAsync()
    {
        PagedResult<TDto> result = new() { TotalItems = await _query.CountAsync(), PageSize = pageSize, PageNumber = pageNumber };
        var items = await PagingHelper.ApplyPagingAsync(_query, pageSize, pageNumber);
        result.Items = mapper.Map<List<TDto>>(items);
        return result;
    }
}
