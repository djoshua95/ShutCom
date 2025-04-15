namespace MysticMadness.Dto;

public class PagedOrderRequest
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

