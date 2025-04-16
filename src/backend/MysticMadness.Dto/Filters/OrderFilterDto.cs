using MysticMadness.Model.Enums;

namespace MysticMadness.Dto.Filters;

public class OrderFilterDto : PagedRequest
{
    public int UserId { get; set; }
    public OrderStatus? Status { get; set; }
}