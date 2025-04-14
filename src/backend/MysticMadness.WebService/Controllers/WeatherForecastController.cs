using Microsoft.AspNetCore.Mvc;

namespace MysticMadness.WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly List<string> Summaries = [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Summaries);
    }

    [HttpPost]
    public IActionResult Post([FromBody] string weather)
    {
        Summaries.Add(weather);
        return Ok(weather);
    }

    [HttpPut]
    public IActionResult Update(int index, [FromBody] string value)
    {
        if (index > 0 || index < Summaries.Count)
        {
            Summaries[index] = value;
            return Ok(Summaries);
        }
        return BadRequest("Index out of bounds");
    }

    [HttpDelete]
    public IActionResult Delete(int index)
    {
        if (index > 0 || index < Summaries.Count)
        {
            Summaries.RemoveAt(index);
            return Ok(Summaries);
        }
        return BadRequest("Index out of bounds");
    }
}
