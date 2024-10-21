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

        [HttpGet]
        public IActionResult AddPlantingDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlantingDetails(CropPlantingViewModel model)
        {
            if (ModelState.IsValid)
            {
                string location = "YourLocation";  // You can make this dynamic as well (user-input)
                double? currentTemperature = await _weatherService.GetTemperatureAsync(location);

                if (currentTemperature.HasValue)
                {
                    // Check if current temperature is close to the preferred temperature
                    if (Math.Abs(currentTemperature.Value - model.PreferredTemperature) <= 2)  // +/- 2 degrees tolerance
                    {
                        model.OptimalPlantingDate = DateTime.Now;
                    }
                    else
                    {
                        model.OptimalPlantingDate = DateTime.Now.AddDays(7);  // Default to 7 days in the future
                    }

                    return View("OptimalPlantingResult", model);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to retrieve weather data. Please try again.");
                }
            }
            return View(model);
        }
    }
}

