using System.Linq;
using FarmTrack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FarmTrack.Models;

namespace FarmTrack.Controllers
{
    public class RemindersController : Controller
    {
        private readonly FarmTrackContext _context;

        public RemindersController(FarmTrackContext context)
        {
            _context = context;
        }

        // Action to list all reminders
        public IActionResult Index()
        {
            var reminders = _context.Reminders.ToList();
            return View(reminders);
        }

        // Action to create a reminder
        public IActionResult Create()
        {
            ViewBag.ReminderTypes = new SelectList(new[] { "Plantation", "Watering", "Fertilizing", "Harvest" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Reminders.Add(reminder);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ReminderTypes = new SelectList(new[] { "Plantation", "Watering", "Fertilizing", "Harvest" });
            return View(reminder);
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteReminder(int reminderId)
        {
            var reminder = await _context.Reminders.FindAsync(reminderId);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Display the ManageEmailListPassword form
        public IActionResult ManageEmailListPassword()
        {
            return View();
        }

        // POST: Handle ManageEmailList password submission
        [HttpPost]
        public IActionResult ManageEmailListPassword(string password)
        {
            const string requiredPassword = "123"; // Hardcoded password

            if (password == requiredPassword)
            {
                // Set a session variable to indicate the user is authenticated
                HttpContext.Session.SetString("EmailListAccessGranted", "true");
                
                // Redirect to ManageEmailList view
                return RedirectToAction("ManageEmailList");
            }
            else
            {
                ViewBag.Error = "Incorrect password. Please try again.";
                return View();
            }
        }

        // GET: ManageEmailList (access restricted)
        public IActionResult ManageEmailList()
        {
            // Check session variable to confirm authentication
            if (HttpContext.Session.GetString("EmailListAccessGranted") != "true")
            {
                // Redirect to password form if session variable is not set
                return RedirectToAction("ManageEmailListPassword");
            }

            var emailList = new EmailListViewModel
            {
                EmailAddresses = _context.EmailLists.ToList()
            };
            return View(emailList);
        }

        // POST: Add email to the email list
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmail(EmailListViewModel model)
        {
            if (!string.IsNullOrEmpty(model.NewEmail))
            {
                var newEmail = new EmailList { EmailAddress = model.NewEmail };
                _context.EmailLists.Add(newEmail);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ManageEmailList));
        }

        // POST: Delete email from the email list
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmail(int emailId)
        {
            var emailToDelete = _context.EmailLists.Find(emailId);
            if (emailToDelete != null)
            {
                _context.EmailLists.Remove(emailToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ManageEmailList));
        }
    }
}
