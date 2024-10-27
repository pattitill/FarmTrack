using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarmTrack.Models;
using FarmTrack.Services;
using FarmTrack.Data; // Ensure to add this for the context

namespace FarmTrack.Controllers
{
    public class PlantingController : Controller
    {
        private readonly WeatherService _weatherService;
        private readonly FarmTrackContext _context;

        public PlantingController(WeatherService weatherService, FarmTrackContext context)
        {
            _weatherService = weatherService;
            _context = context;
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
                string location = model.Location;

                double? currentTemperature = await _weatherService.GetTemperatureAsync(location);

                if (currentTemperature.HasValue)
                {
                    if (Math.Abs(currentTemperature.Value - model.PreferredTemperature) <= 2)
                    {
                        model.OptimalPlantingDate = DateTime.Now;
                    }
                    else
                    {
                        model.OptimalPlantingDate = DateTime.Now.AddDays(7);
                    }

                    return View("OptimalPlantingResult", model);
                }
                else
                {
                    ModelState.AddModelError("", "Unable to retrieve weather data. Please check the location and try again.");
                }
            }
            return View(model);
        }

        // GET: Planting history of all crops
        [HttpGet]
        public IActionResult History()
        {
            var crops = _context.Crops
                .Where(c => c.Harvested) // Filter to include only harvested crops
                .Select(c => new 
                {
                    c.CropName,
                    c.CropType, // Added CropType
                    c.PlantingDate,
                    c.ExpectedHarvestDate,
                    ActualGrowthTime = c.HarvestDate.HasValue 
                        ? (c.HarvestDate.Value - c.PlantingDate).TotalDays.ToString("0") + " days"
                        : "N/A",
                    ActualHarvestDate = c.HarvestDate.HasValue 
                        ? c.HarvestDate.Value.ToString("yyyy-MM-dd") 
                        : "N/A"
                })
                .ToList();

            return View(crops);
        }
    }
}
