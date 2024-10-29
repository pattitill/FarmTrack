using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; 
using Newtonsoft.Json.Linq;

namespace FarmTrack.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherApi:ApiKey"];  // Retrieves the API key from appsettings.json
        }

        public async Task<double?> GetTemperatureAsync(string location)
        {
            // WeatherAPI endpoint
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={location}&aqi=no";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseData);

                // Access temperature in Celsius from WeatherAPI response structure
                return (double?)json["current"]["temp_c"];
            }

            return null;  // Return null if the API call fails
        }
    }
}
