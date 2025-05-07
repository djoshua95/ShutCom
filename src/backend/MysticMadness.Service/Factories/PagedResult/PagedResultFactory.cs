using AutoMapper;

namespace MysticMadness.Service.Factories.PagedResult;

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
