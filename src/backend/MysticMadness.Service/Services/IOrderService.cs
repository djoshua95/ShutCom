using MysticMadness.Dto;
using MysticMadness.Dto.Filters;
using MysticMadness.Service.Generics;

namespace MysticMadness.Service.Services;

public interface IOrderService
{
    Task<DataResult<List<OrderDto>>> GetAllOrdersGivenAnUserIdAsync(int userId);

    Task<DataResult<PagedResult<OrderDto>>> GetPagedOrdersGivenAnUserIdAsync(OrderFilterDto filter);
}
