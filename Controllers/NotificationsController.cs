using CaseDictonaryWebAPI.Models;
using CaseDictonaryWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseDictonaryWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationsController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            try
            {
                await _notificationService.SendAsync(request);
                return Ok("Notification sent successfully");
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> SendNotificationCase([FromBody] NotificationRequest request)
        {
            try
            {
                await _notificationService.SendCaseAsync(request);
                return Ok("Notification sent successfully");
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
