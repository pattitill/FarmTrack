using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FarmTrack.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double?> GetTemperatureAsync(string location)
        {
            string apiKey = "YOUR_API_KEY";  // Replace with your OpenWeather API key
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseData);
                return (double?)json["main"]["temp"];
            }
            return null;  // Return null if the API call fails
        }
    }
}

