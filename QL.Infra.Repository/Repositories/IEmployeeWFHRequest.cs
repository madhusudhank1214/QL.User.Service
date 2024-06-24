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
       // Task<IEnumerable<QLApps>> GetAppName();
        Task<IEnumerable<ResultsInput>> GetAppName();
        Task<IEnumerable<ResultsInput>> GetRequestType();
        Task<IEnumerable<ResultsInput>> GetStatus();
        //Task<IEnumerable<QLRequestTypes>> GetRequestType();
        //Task<IEnumerable<QLWFHStatus>> GetStatus();
    }
}
