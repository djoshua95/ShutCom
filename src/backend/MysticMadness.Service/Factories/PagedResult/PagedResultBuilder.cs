using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.Generics;
using MysticMadness.Service.Utils;

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
        _query = _query.ApplySorting(keySelectors);
        return this;
    }

    public IMappedPagedResultBuilder<TEntity, TDto> WithMapping<TDto>()
    {
        return new MappedPagedResultBuilder<TEntity, TDto>(mapper, _query, pageSize, pageNumber);
    }

    public async Task<PagedResult<TEntity>> BuildAsync()
    {
        return new()
        {
            TotalItems = await _query.CountAsync(),
            PageSize = pageSize,
            PageNumber = pageNumber,
            Items = await PagingHelper.ApplyPagingAsync(_query, pageSize, pageNumber)
        };
    }
}