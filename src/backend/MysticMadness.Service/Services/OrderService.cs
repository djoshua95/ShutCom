using Microsoft.EntityFrameworkCore;
using MysticMadness.Service.Generics;
using ShutCom.Domain.UnitOfWorkPattern;
using ShutCom.Model.Entities;

namespace MysticMadness.Service.Services;

public class OrderService(IUnitOfWork unitOfWork) : IOrderService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<DataResult<List<Order>>> GetAllOrdersGivenAnUserIdAsync(int userId)
    {
        DataResult<List<Order>> dataResult = new();
        try
        {
            var result = _unitOfWork
                .OrderRepository
                .GetFiltered(o => o.UserId == userId);
            dataResult.Data = await result.ToListAsync();
            dataResult.Success = true;
        }
        catch (Exception ex)
        {
            dataResult.Success = false;
            dataResult.Message = ex.Message;
        }
        return dataResult;
    }   
}