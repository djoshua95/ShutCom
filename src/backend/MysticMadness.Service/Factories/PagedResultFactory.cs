using AutoMapper;
using MysticMadness.Service.Factories.PagedResult;

namespace MysticMadness.Service.Factories;

public interface IPagedResultFactory
{
    IPagedResultBuilder<TEntity> Create<TEntity>(IQueryable<TEntity> source, int pageSize, int pageNumber);
}

public class PagedResultFactory(IMapper mapper) : IPagedResultFactory
{
    public IPagedResultBuilder<TEntity> Create<TEntity>(IQueryable<TEntity> source, int pageSize, int pageNumber)
    {
        return new PagedResultBuilder<TEntity>(mapper, source, pageSize, pageNumber);
    }
}