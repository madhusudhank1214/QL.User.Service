using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QL.Infra.Repository.InfraRepos.EmployeeWFHRequest;

namespace QL.Infra.Repository.Repositories
{
    public interface IEmployeeWFHRequest
    {
        IEnumerable<QLEmployee> GetAllEmployees();
        IEnumerable<WFHRequests> GetAllWFHRequests();
        IEnumerable<WFHRequests> GetWFHRequestsByEmployee(string EmployeeID);
        WFHRequests AddWFHRequestsByEmployee(string EmployeeID);
        WFHRequests UpdateWFHRequestsByEmployee(string EmployeeID);
        Task<IEnumerable<MasterDto>> GetAppName();
        Task<IEnumerable<MasterDto>> GetRequestType();
        Task<IEnumerable<MasterDto>> GetStatus();
    }
}
