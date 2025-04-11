namespace MysticMadness.Service.Generics;

public class PagedResult<TResult>
{
    private const int PAGE_SIZE_LIMIT = 10;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public List<TResult> Items { get; set; } = [];

    public PagedResult(int pageNumber, int pageSize, int totalItems, List<TResult> items)
    {
        int lastPage = (int)Math.Ceiling(((decimal)totalItems)/pageSize);
        PageNumber = pageNumber;
        if (pageNumber < 1 && pageNumber > lastPage)
        {
            PageNumber = 1;
        }
        PageSize = pageSize;
        if (pageSize > PAGE_SIZE_LIMIT)
        {
            PageSize = PAGE_SIZE_LIMIT;
        }
    }
}