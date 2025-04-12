using Microsoft.EntityFrameworkCore;

namespace MysticMadness.Service.Generics;

public class PagedResult<TResult>
{
    private const int PAGE_SIZE_LIMIT = 10;
    private const int PAGE_SIZE_DEFAULT_VALUE = 5;
    private const int PAGE_NUMBER_DEFAULT_VALUE = 1;

    private int _pageNumber;
    private int _pageSize;
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = ValidatePageNumber(value);
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = ValidatePageSize(value);
    }
    public int TotalItems { get; set; }
    public List<TResult> Items { get; set; } = [];

    private int ValidatePageNumber(int pageNumber)
    {
        int lastPage = TotalItems / PageSize;
        if (TotalItems % PageSize > 0) lastPage++;
        if (pageNumber > 0 && pageNumber <= lastPage) return pageNumber;
        return PAGE_NUMBER_DEFAULT_VALUE;
    }

    private static int ValidatePageSize(int pageSize)
    {
        if (pageSize > 0 && pageSize <= PAGE_SIZE_LIMIT) return pageSize;
        return PAGE_SIZE_DEFAULT_VALUE;
    }

    private PagedResult() { }

    public static async Task<PagedResult<TResult>> BuildFromQuery(IQueryable<TResult> source, int pageSize, int pageNumber)
    {
        PagedResult<TResult> result = new() { PageSize = pageSize, PageNumber = pageNumber, TotalItems = await source.CountAsync() };
        result.Items = await source
            .Skip(result.PageSize * (result.PageNumber - 1))
            .Take(result.PageSize)
            .ToListAsync();
        return result;
    }
}