﻿using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface IEmployeeWFHRequest
    {
        Task<IEnumerable<QLEmployee>> GetAllEmployees();
        IEnumerable<WFHRequests> GetAllWFHRequests();
        IEnumerable<WFHRequests> GetWFHRequestsByEmployee(string EmployeeID);
        WFHRequests AddWFHRequestsByEmployee(string EmployeeID);
        WFHRequests UpdateWFHRequestsByEmployee(string EmployeeID);
        
        Task<IEnumerable<RequestsDto>> GetAllRequestDetails();
        Task<IEnumerable<RequestsDto>> GetAllRequestsByProjectId(string projectId);
        Task<IEnumerable<RequestsDto>> GetAllRequestsByEmployeeId(string employeeId);
        Task<IEnumerable<RequestsDto>> SaveRequests(WFHRequests request);
        Task<IEnumerable<RequestCountDto>> GetAllRequestCountByEmployeeId(string employeeId);
        Task<IEnumerable<EmployeeProjectDetails>> GetProjectsByEmployeeId(string employeeId);
        Task<IEnumerable<ProjectsEmployeeDetailsDto>> GetEmployeeDetailsForProject(string project);
        Task<bool> UpdateRequestStatus(Guid requestid, string status);
        
        
        Task<IEnumerable<QLEmployee>> GetEmployeesDetailsForEmployeeId(string employeeId);
    }
}
