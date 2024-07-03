using Dapper;
using Microsoft.Extensions.Configuration;
using QL.Infra.Models.Constants;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace QL.Infra.Repository.InfraRepos
{
    public class EmployeeWFHRequest : IEmployeeWFHRequest,IDisposable
    {
        private readonly IConfiguration configuration;

        public EmployeeWFHRequest(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public WFHRequests AddWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QLEmployee>> GetAllEmployees()
        {
            List<QLEmployee> _qlemployees;
            var sql = "SELECT EmpId AS EmployeeId,Name, Email, RoleId, ProjectId,MobileNumber  FROM QLEmployees";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result =  await connection.QueryAsync<QLEmployee>(sql);
                return (IEnumerable<QLEmployee>)result;
            }
            //return _qlemployees;
        }
        public IEnumerable<WFHRequests> GetAllWFHRequests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WFHRequests> GetWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public WFHRequests UpdateWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MasterDto>> GetAppName()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var spName = "GetAppName";
                return await connection.QueryAsync<MasterDto>(spName, commandType: CommandType.StoredProcedure
            );
            }
        }
        public async Task<IEnumerable<MasterDto>> GetRequestType()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var spName = "GetRequestType";
                return await connection.QueryAsync<MasterDto>(spName, commandType: CommandType.StoredProcedure
            );
            }
        }
        public async Task<IEnumerable<MasterDto>> GetStatus()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var spName = "GetStatus";
                return await connection.QueryAsync<MasterDto>(spName, commandType: CommandType.StoredProcedure
            );
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                this.Dispose();
                disposing = true;
            }

        }

        public async Task<IEnumerable<RequestsDto>> GetAllRequestDetails()
        {
            IEnumerable<RequestsDto> result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetAllRequestsDetails";
                     result= await connection.QueryAsync<RequestsDto>(spName, commandType: CommandType.StoredProcedure);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByProjectId(string projectId)
        {
            IEnumerable<RequestsDto> result;
            try
            {
                var parameters = new { ProjectId = projectId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetAllRequestsByProjectId";
                    result = await connection.QueryAsync<RequestsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<RequestsDto>> GetAllRequestsByEmployeeId(string employeeId)
        {
            IEnumerable<RequestsDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetAllRequestsByEmployeeId";
                    result = await connection.QueryAsync<RequestsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<RequestsDto>> SaveRequests(WFHRequests request)
        {
            IEnumerable<RequestsDto> result;
            try
            {
                var parameters = new { RequestId=request.RequestId, EmployeeId = request.EmployeeId, Status =  RequestStatus.Created,
                    Comments= request.Comments, FromDate= request.FromDate, ToDate= request.ToDate, RequestType = RequestTypes.WFH
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "SaveRequest";
                    result = await connection.QueryAsync<RequestsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<RequestCountDto>> GetAllRequestCountByEmployeeId(string employeeId)
        {
            IEnumerable<RequestCountDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetAllRequestCountByEmployeeId";
                    result = await connection.QueryAsync<RequestCountDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<EmployeeProjectDetails>> GetProjectsByEmployeeId(string employeeId)
        {
            IEnumerable<EmployeeProjectDetails> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetProjectsByEmployeeId";
                    result = await connection.QueryAsync<EmployeeProjectDetails>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<ProjectsEmployeeDetailsDto>> GetEmployeeDetailsForProject(string project)
        {
            IEnumerable<ProjectsEmployeeDetailsDto> result;
            try
            {
                var parameters = new { Project = project };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetEmployeeDetailsForProject";
                    result = await connection.QueryAsync<ProjectsEmployeeDetailsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int GetRequestStatusValue(string status)
        {
            string requeststatus = status;
            int requeststatusid = 0;
            switch (status)
            {
                case "Approved":
                    requeststatusid = 1;
                    break;
                case "Rejected":
                    requeststatusid = 2;
                    break;
                case "Created":
                    requeststatusid = 3;
                    break;
                case "Hold":
                    requeststatusid = 4;
                    break;
                case "Read":
                    requeststatusid = 5;
                    break;
                case "UnRead":
                    requeststatusid = 6;
                    break;
                case "Completed":
                    requeststatusid = 7;
                    break;
            }
            return requeststatusid;
        }

        public int GetNotificationStatusValue(string notificationStatus)
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

        public async Task<bool> UpdateRequestStatus(Guid requestId, string status)
        {
            int requeststatusid = GetRequestStatusValue(status);
            try
            {
                var parameters = new { RequestId = requestId, Status = requeststatusid };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "UpdateRequestStatus";
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

        public async Task<bool> SaveNotifications(Notifications notificationRequest)
        {
            int notificationStatusId = GetNotificationStatusValue(notificationRequest.NotificationStatus);
            try
            {
                var parameters = new
                {
                    Title = notificationRequest.Title,
                    NotificationStatus = notificationStatusId,
                    CreatedDate= DateTime.Now,
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
    }
}
