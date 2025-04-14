using Microsoft.AspNetCore.Mvc;
using MysticMadness.Service.Services;

namespace MysticMadness.WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> Get(int userId)
    {
        var result = await _orderService.GetAllOrdersGivenAnUserIdAsync(userId);
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }
}