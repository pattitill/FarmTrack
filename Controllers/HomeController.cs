using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FarmTrack.Models;
using Microsoft.AspNetCore.Mvc;
using FarmTrack.Models; 

namespace FarmTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Privacy page that requires password every time
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Password entry form
        public IActionResult PrivacyPassword()
        {
            return View();
        }

        // POST: Handle password submission
        [HttpPost]
        public IActionResult PrivacyPassword(string password)
        {
            const string requiredPassword = "123"; // Hardcoded password

            if (password == requiredPassword)
            {
                // Redirect to the actual Privacy view if password is correct
                return RedirectToAction("ShowPrivacy");
            }
            else
            {
                // Show error message if the password is incorrect
                ViewBag.Error = "Incorrect password. Please try again.";
                return View();
            }
        }

        // GET: The actual Privacy page content (shown only after correct password)
        public IActionResult ShowPrivacy()
        {
            return View("Privacy");
        }
    }
}
