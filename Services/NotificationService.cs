using CaseDictonaryWebAPI.Contexts;
using CaseDictonaryWebAPI.Models;

namespace CaseDictonaryWebAPI.Services
{
    public class NotificationService
    {
        private readonly NotificationContext _context;

        public NotificationService(NotificationContext context)
        {
            _context = context;
        }

        public async Task SendAsync(NotificationRequest request)
        {
            await _context.SendNotificationAsync(request);
        }

        public async Task SendCaseAsync(NotificationRequest request)
        {
            await _context.SendNotificationCaseAsync(request);
        }
    }
}
