using Microsoft.AspNetCore.Mvc;
using MysticMadness.Service.Services;

namespace ShutCom.WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService)
{
    private readonly IOrderService _orderService = orderService;
}