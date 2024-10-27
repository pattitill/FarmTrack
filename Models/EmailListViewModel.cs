namespace FarmTrack.Models
{
    public class EmailListViewModel
    {
        public List<EmailList> EmailAddresses { get; set; } = new List<EmailList>();  // Collection of emails
        public string NewEmail { get; set; }  // For adding a new email in the form
    }
}
