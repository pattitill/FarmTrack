using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarmTrack.Models;
using FarmTrack.Services;

namespace FarmTrack.Controllers
{
    public class PlantingController : Controller
    {
        private readonly WeatherService _weatherService;

        public PlantingController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // GET: Display the form to add planting details
        [HttpGet]
        public IActionResult AddPlantingDetails()
        {
            return View();
        }

        // POST: Calculate optimal planting date based on user input and weather data
        [HttpPost]
        public async Task<IActionResult> AddPlantingDetails(OptimalPlanting model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the location from the user input (model)
                string location = model.Location;

                // Call the WeatherService to get the current temperature for the location
                double? currentTemperature = await _weatherService.GetTemperatureAsync(location);

                if (currentTemperature.HasValue)
                {
                    // If current temperature is within 2 degrees of the preferred temperature, set planting to now
                    if (Math.Abs(currentTemperature.Value - model.PreferredTemperature) <= 2)
                    {
                        model.OptimalPlantingDate = DateTime.Now;
                    }
                    else
                    {
                        // Otherwise, suggest a planting date 7 days later
                        model.OptimalPlantingDate = DateTime.Now.AddDays(7);
                    }

                    // Return the result to a view that shows the optimal planting date
                    return View("OptimalPlantingResult", model);
                }
                else
                {
                    // Handle case where weather data could not be retrieved
                    ModelState.AddModelError("", "Unable to retrieve weather data. Please check the location and try again.");
                }
            }
            return View(model);
        }
    }
}
