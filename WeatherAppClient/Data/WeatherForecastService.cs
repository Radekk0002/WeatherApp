using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherAppClient.Data
{
    public class WeatherForecastService
    {
        public async Task<IShortWeatherForecast[]> GetDataAsync(decimal lat, decimal lon, string place)
        {
            HttpClient Http = new HttpClient();
            var data = await Http.GetFromJsonAsync<JsonElement>($"https://api.radekkisiel.pl/api/weather/?Latitude={lat}&Longitude={lon}");
            DateTime date = DateTime.Now;

            IShortWeatherForecast[] _forecasts = new IShortWeatherForecast[7];
            for (int i = 0; i < _forecasts.Length; i++)
            {
                IShortWeatherForecast swf = new WeatherForecast();

                swf.Date = date.AddDays(i);
                swf.Wind = data.GetProperty("daily")[i].GetProperty("wind_speed").GetDouble();
                swf.TemperatureC = Math.Round(data.GetProperty("daily")[i].GetProperty("temp").GetProperty("day").GetDouble(), 1);
                swf.Summary = data.GetProperty("daily")[i].GetProperty("weather")[0].GetProperty("description").ToString();
                swf.Icon = data.GetProperty("daily")[i].GetProperty("weather")[0].GetProperty("icon").ToString();
                swf.Humidity = data.GetProperty("daily")[i].GetProperty("humidity").GetInt32();
                _forecasts[i] = swf;
            }

            WeatherForecast wf = (WeatherForecast) (_forecasts[0]);

            wf.Place = place;
            wf.Pressure = data.GetProperty("daily")[0].GetProperty("pressure").GetInt32();
            wf.Cloudiness = data.GetProperty("daily")[0].GetProperty("clouds").GetInt32();

            _forecasts[0] = wf;

            return _forecasts;
        }
        
        
    }
}