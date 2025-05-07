using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MysticMadness.Dto.Filters;
using MysticMadness.Service.Services;

namespace MysticMadness.WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet("{userId:int}")]
    [Authorize]
    public async Task<IActionResult> Get(int userId)
    {
        var result = await _orderService.GetAllOrdersGivenAnUserIdAsync(userId);
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("paged")]
    [Authorize]
    public async Task<IActionResult> GetPaged([FromQuery] OrderFilterDto filter)
    {
        var result = await _orderService.GetPagedOrdersGivenAnUserIdAsync(filter);
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }
}
