using CaseDictonaryWebAPI.Contacts;
using CaseDictonaryWebAPI.Models;
using CaseDictonaryWebAPI.Services;
using System.Data;

namespace CaseDictonaryWebAPI.Contexts
{
    public class NotificationContext
    {
        private readonly Dictionary<NotificationType, INotificationStrategy> _strategies;

        public NotificationContext(Dictionary<NotificationType, INotificationStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task SendNotificationAsync(NotificationRequest request)
        {
            if (_strategies.TryGetValue(request.Type, out var strategy))
            {
                await strategy.SendAsync(request);
            }
            else
            {
                throw new NotSupportedException($"Notification type {request.Type} is not supported");
            }
        }


        public async Task SendNotificationCaseAsync(NotificationRequest request)
        {
            INotificationStrategy strategy;

            switch (request.Type)
            {
                case NotificationType.Email:
                    strategy = new EmailNotificationStrategy();
                    await strategy.SendAsync(request);
                    break;
                case NotificationType.SMS:
                    strategy = new SmsNotificationStrategy();
                    await strategy.SendAsync(request);
                    break;
                case NotificationType.Push:
                    strategy = new PushNotificationStrategy();
                    await strategy.SendAsync(request);
                    break;
                default:
                    throw new NotSupportedException($"Notification type {request.Type} is not supported");
            }
        }
    }
}
