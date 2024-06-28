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
    }
}
