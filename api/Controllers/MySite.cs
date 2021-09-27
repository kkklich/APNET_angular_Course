using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MySiteController:ControllerBase
    {
        
        private readonly ILogger<MySiteController> _logger;

        public MySiteController(ILogger<MySiteController> logger)
        {   
            _logger = logger;
        }

        
        private static readonly string[] Summaries = new[]
        {
            "aaaa", "bbbb", "cccc", "dddhh", "123123123123123RRR","234xcvdgliLwERR"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}