using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MysticMadness.Dto;
using MysticMadness.Service.AppConstants;
using MysticMadness.Service.Generics;
using MysticMadness.Service.Utils;
using MysticMadness.Service.Utils.Logging;
using ShutCom.Domain.UnitOfWorkPattern;

namespace MysticMadness.Service.Services;

public class OrderService(IUnitOfWork unitOfWork, ILogger<OrderService> logger, IMapper mapper) : IOrderService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<OrderService> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<DataResult<List<OrderDto>>> GetAllOrdersGivenAnUserIdAsync(int userId)
    {
        DataResult<List<OrderDto>> dataResult = new();
        try
        {
            var result = _unitOfWork
                .OrderRepository
                .GetFiltered(o => o.UserId == userId);
            var mappedData = _mapper.Map<List<OrderDto>>(await result.ToListAsync());
            dataResult.Data = mappedData;
            dataResult.Success = true;
        }
        catch (Exception ex)
        {
            _logger.CustomLogError(new CustomLoggingMessages.ORDS0001 { Ex = ex, UserId = userId });
            dataResult.Success = false;
            dataResult.Message = ErrorMessageBuilder.BuildFromMessageAndCode(
                Constants.ErrorMessages.ERROR_GET_ITEMS_FAILED,
                Constants.ErrorCodes.ORDS0001
            );
        }
        return dataResult;
    }
}