using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration configuration1;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            configuration1 = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(string key, string ty = "str")
        {
            var rng = new Random();

            var rst = Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
             .ToArray().ToList();
            if (!string.IsNullOrWhiteSpace(key))
            {
                var val = configuration1.GetValue<string>(key);
                
                if (ty != "str")
                {
                    var val2 = configuration1.GetSection(key).Get<int>();
                }
                rst.Clear();
                if (!string.IsNullOrWhiteSpace(val))
                {
                    rst.Add(new WeatherForecast { Summary = val });
                }
            }

            return rst;
        }
    }
}
