using CaseDictonaryWebAPI.Contacts;
using CaseDictonaryWebAPI.Models;

namespace CaseDictonaryWebAPI.Services
{
    // EmailNotificationStrategy.cs
    public class EmailNotificationStrategy : INotificationStrategy
    {
        public async Task SendAsync(NotificationRequest request)
        {
            // Actual email sending logic
            await Task.Delay(100); // Simulate API call
            Console.WriteLine($"Email sent to {request.Recipient}: {request.Message}");
        }
    }

    // SmsNotificationStrategy.cs
    public class SmsNotificationStrategy : INotificationStrategy
    {
        public async Task SendAsync(NotificationRequest request)
        {
            // Actual SMS sending logic
            await Task.Delay(100);
            Console.WriteLine($"SMS sent to {request.Recipient}: {request.Message}");
        }
    }

    // PushNotificationStrategy.cs
    public class PushNotificationStrategy : INotificationStrategy
    {
        public async Task SendAsync(NotificationRequest request)
        {
            // Actual push notification logic
            await Task.Delay(100);
            Console.WriteLine($"Push notification sent to {request.Recipient}: {request.Message}");
        }
    }
}
