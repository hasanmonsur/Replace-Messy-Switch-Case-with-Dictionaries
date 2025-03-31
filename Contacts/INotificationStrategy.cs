using CaseDictonaryWebAPI.Models;

namespace CaseDictonaryWebAPI.Contacts
{
    public interface INotificationStrategy
    {
        Task SendAsync(NotificationRequest request);
    }
}
