using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetNotifications()
        {
            // Mock data for notifications
            var notifications = new List<NotificationItem>
            {
                new NotificationItem
                {
                    Avatar = "https://api.dicebear.com/7.x/miniavs/svg?seed=1",
                    Date = DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsRead = false,
                    Message = "You have a new message from the system administrator.",
                    Title = "System Notification"
                },
                new NotificationItem
                {
                    Avatar = "https://api.dicebear.com/7.x/miniavs/svg?seed=2",
                    Date = DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsRead = false,
                    Message = "Your profile has been updated successfully.",
                    Title = "Profile Update"
                },
                new NotificationItem
                {
                    Avatar = "https://api.dicebear.com/7.x/miniavs/svg?seed=3",
                    Date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsRead = true,
                    Message = "Welcome to the React Antd Admin system!",
                    Title = "Welcome Message"
                },
                new NotificationItem
                {
                    Avatar = "https://api.dicebear.com/7.x/miniavs/svg?seed=4",
                    Date = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsRead = true,
                    Message = "System maintenance will be performed tonight.",
                    Title = "Maintenance Notice"
                }
            };

            return Ok(new { result = notifications });
        }
    }

    public class NotificationItem
    {
        public string Avatar { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public bool? IsRead { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}