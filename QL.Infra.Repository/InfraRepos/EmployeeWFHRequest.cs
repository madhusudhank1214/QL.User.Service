using Dapper;
using Microsoft.Extensions.Configuration;
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

        public IEnumerable<QLEmployee> GetAllEmployees()
        {
            List<QLEmployee> _qlemployees = new()
            { 
                new() { Email="mkasarapu@qentelli.com", EmployeeId= "QE1901", EmployeeName="Madhu"  },
                new() { Email="raju@qentelli.com", EmployeeId= "QE1902", EmployeeName="Raju"  },
                new() { Email="rani@qentelli.com", EmployeeId= "QE1903", EmployeeName="Rani"  }
            };
            return _qlemployees;
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
        public async Task<IEnumerable<MasterDto>>GetAppName()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            { 
                connection.Open();
                var spName = "GetAppName";
                return await connection.QueryAsync<MasterDto>(spName,commandType: CommandType.StoredProcedure
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
    }
}
