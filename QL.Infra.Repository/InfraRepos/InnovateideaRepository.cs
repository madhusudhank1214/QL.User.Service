using Microsoft.Extensions.Configuration;
using QL.Infra.Models.Dto;
using QL.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using QL.Infra.Models.Employee;

namespace QL.Infra.Repository.InfraRepos
{
    public class InnovateideaRepository : IInnovateideaRepository
    {
        private readonly IConfiguration configuration;

        public InnovateideaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<QLIdeaTrackerDto>> GetAllQLInnovativeIdeas()
        {
            IEnumerable<QLIdeaTrackerDto> result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetAllInnovateIdeas";
                    result = await connection.QueryAsync<QLIdeaTrackerDto>(spName, null, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<IEnumerable<QLIdeaTrackerDto>> GetQLIdeasByEmployee(string employeeId)
        {
            IEnumerable<QLIdeaTrackerDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    //var spName = "GetIdeaTracker";
                    var spName = "GetAllInnovateIdeas";
                    result = await connection.QueryAsync<QLIdeaTrackerDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<IEnumerable<QLIdeaDetailsDto>> GetQLIdeaDetails()
        {
            List<QLIdeaDetailsDto> _qLIdeaDetailsDto;
            var sql = "SELECT IdeaDescription, IdeaType FROM QLIdeaDetails";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<QLIdeaDetailsDto>(sql);
                return (IEnumerable<QLIdeaDetailsDto>)result;
            }
        }
        public async Task<bool> SaveIdeaTracker(IdeaTracker ideaTracker)
        {
            int ideaTypeId = GetIdeaTypeValue(ideaTracker.IdeaType);
            int status = GetRequestStatusValue(ideaTracker.Status);
            try
            {
                var parameters = new
                {
                    Title = ideaTracker.Title,
                    IdeaDescription = ideaTracker.IdeaDescription,
                    IdeaType = ideaTypeId,
                    Benefits = ideaTracker.Benefits,
                    Technology = ideaTracker.Technology,
                    EstimatedEffort = ideaTracker.EstimatedEffort,
                    ActualEffort = ideaTracker.ActualEffort,
                    AnnualSaving = ideaTracker.AnnualSaving,
                    Status = status,
                    ResourceName = ideaTracker.ResourceName
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "SaveIdeaTracker";
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
        private int GetIdeaTypeValue(string ideatype)
        {
            string ideaType = ideatype;
            int ideaTypeId = 0;
            switch (ideaType)
            {
                case "Tax":
                    ideaTypeId = 1;
                    break;
                case "IMMIGRATON":
                    ideaTypeId = 2;
                    break;
                case "TCB":
                    ideaTypeId = 3;
                    break;
            }
            return ideaTypeId;
        }

        private int GetRequestStatusValue(string status)
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
    }
}
