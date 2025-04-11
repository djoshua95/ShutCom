using MysticMadness.Service.Generics;
using ShutCom.Model.Entities;

namespace MysticMadness.Service.Services;

public interface IOrderService
{
    Task<DataResult<List<Order>>> GetAllOrdersGivenAnUserIdAsync(int userId);
}