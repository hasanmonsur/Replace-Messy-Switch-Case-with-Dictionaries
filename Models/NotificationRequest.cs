namespace CaseDictonaryWebAPI.Models
{
    public class NotificationRequest
    {
        public NotificationType Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
