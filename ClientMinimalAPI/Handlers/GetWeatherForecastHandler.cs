using ClientMinimalAPI.Models;
using libCustomMediatR;

namespace ClientMinimalAPI.Handlers
{
    public class GetWeatherForecastHandler : IRequestHandler<WeatherForecastRequest, List<WeatherForecast>>
    {
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<List<WeatherForecast>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {


            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList());
        }
    }
}
