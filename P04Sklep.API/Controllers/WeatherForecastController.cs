using Microsoft.AspNetCore.Mvc;

namespace P04Sklep.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetXX()
    {
        _logger.Log(LogLevel.Information,"get method");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    //https://localhost:7140/api/WeatherForecast/onlytwo
    [HttpGet("onlyTwo")]
    public IEnumerable<WeatherForecast> GetOnlyTwoWeatherForecast()
    {
        return new WeatherForecast[2]
        {
            new WeatherForecast()
            {
                Summary="one"
            },
            new WeatherForecast()
            {
                Summary="two"
            }
        };
    }

    //https://localhost:7140/api/WeatherForecast/search?number=3
    [HttpGet("search")]
    public IEnumerable<WeatherForecast> SearchWeatherForecast([FromQuery]int number)
    {
        return Enumerable.Range(1, number).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    //https://localhost:7140/api/WeatherForecast/test/hello?number=5&otherParameter=6
        /*{
        "name": "jan",
        "age" : 40
        }*/
    [HttpGet("test/{myParam}")]
    public string GetValueFromPath([FromRoute]string myParam, [FromQuery]int number, [FromBody]Person person)
    {
        return $"this is result: myParam: {myParam}, number: {number}, Person: name:{person.Name}, age: {person.Age}";
    }




}
