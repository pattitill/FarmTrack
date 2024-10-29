
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FarmTrack.Services
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("farmtrackreminder@gmail.com", "idwzgdsfqfmpvkcw"); // Password for my email account (please keep private)
                smtp.EnableSsl = true;

                var mailMessage = new MailMessage("farmtrackreminder@gmail.com", toEmail, subject, message);
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
