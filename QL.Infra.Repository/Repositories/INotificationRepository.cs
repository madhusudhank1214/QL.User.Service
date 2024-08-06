using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface INotificationRepository
    {
        Task<bool> SaveNotifications(Notifications notification);
        Task<bool> UpdateNotifications(Notifications request);

        Task<IEnumerable<NotificationsDto>> GetNotificationsByEmployeeId(string employeeId);
        Task<IEnumerable<IdeasNotificationsDto>> GetIdeasNotificationsByEmployeeId(string employeeId);
    }
}
