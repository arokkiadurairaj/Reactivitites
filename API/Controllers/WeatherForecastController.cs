using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(DataContext dataContext, ILogger<WeatherForecastController> logger)
        {
            this.dataContext = dataContext;
            _logger = logger;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext dataContext;


        [HttpGet]
        public async Task<IEnumerable<Domains.WeatherForecast>> Get()
        {
            var forecasts = await this.dataContext.WeatherForecasts.ToListAsync();
            return forecasts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domains.WeatherForecast>> Get(int id)
        {
            var forecast = await this.dataContext.WeatherForecasts.FindAsync(id);
            return forecast;
        }
    }
}

