using Microsoft.Extensions.Configuration;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace QL.Infra.Repository.InfraRepos
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IConfiguration configuration;

        public NotificationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<bool> SaveNotifications(Notifications notificationRequest)
        {
            int notificationStatusId = GetNotificationStatusValue(notificationRequest.NotificationStatus);
            try
            {
                var parameters = new
                {
                    Title = notificationRequest.Title,
                    NotificationStatus = notificationStatusId,
                    CreatedDate = DateTime.Now,
                    RequestId = notificationRequest.RequestId,
                    Read = notificationRequest.Read
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "SaveNotifications";
                    int result = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateNotifications(Notifications notificationRequest)
        {
            int notificationStatusId = GetNotificationStatusValue(notificationRequest.NotificationStatus);
            try
            {
                var parameters = new
                {
                    Title = notificationRequest.Title,
                    NotificationStatus = notificationStatusId,
                    ApprovedDate = notificationRequest.ApprovedDate,
                    RequestId = notificationRequest.RequestId,
                    Read = notificationRequest.Read
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "UpdateNotification";
                    int result = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<NotificationsDto>> GetNotificationsByEmployeeId(string employeeId)
        {
            IEnumerable<NotificationsDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetNotificationsByEmployeeId";
                    result = await connection.QueryAsync<NotificationsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<IEnumerable<IdeasNotificationsDto>> GetIdeasNotificationsByEmployeeId(string employeeId)
        {
            IEnumerable<IdeasNotificationsDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetIdeasNotificationsByEmployeeId";
                    result = await connection.QueryAsync<IdeasNotificationsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private int GetNotificationStatusValue(string notificationStatus)
        {
            string status = notificationStatus;
            int notificationStatusId = 0;
            switch (status)
            {
                case "Ready":
                    notificationStatusId = 1;
                    break;
                case "Sent":
                    notificationStatusId = 2;
                    break;
            }
            return notificationStatusId;
        }
    }
}
