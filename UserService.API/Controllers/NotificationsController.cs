using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ILogger<NotificationsController> _logger;
        private INotificationRepository _notificationrepo;

        public NotificationsController(INotificationRepository notificationrepo, ILogger<NotificationsController> logger)
        {
            _logger = logger;
            _notificationrepo = notificationrepo;
        }

        [HttpGet("getNotificationsByEmployeeId")]
        public async Task<IEnumerable<NotificationsDto>> GetNotificationsByEmployeeId(string employeeId)
        {
            return await _notificationrepo.GetNotificationsByEmployeeId(employeeId);
        }

        [HttpPost("saveNotifications")]
        public async Task<bool> SaveNotifications(Notifications notification)
        {
            return await _notificationrepo.SaveNotifications(notification);
        }

        [HttpPut("updateNotification")]
        public async Task<bool> UpdateRequestStatus(Notifications notification)
        {
            return await _notificationrepo.UpdateNotifications(notification);
        }
        [HttpGet("GetIdeasNotificationsByEmployeeId")]
        public async Task<IEnumerable<IdeasNotificationsDto>> GetIdeasNotificationsByEmployeeId(string employeeId)
        {
            return await _notificationrepo.GetIdeasNotificationsByEmployeeId(employeeId);
        }
    }
}
