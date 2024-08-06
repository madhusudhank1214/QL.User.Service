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
using QL.Infra.Models.InnovateIdea;

namespace QL.Infra.Repository.InfraRepos
{
    public class MasterInfomation: IMasterInfomation
    {
        private readonly IConfiguration configuration;

        public MasterInfomation(IConfiguration configuration)
        {
            this.configuration = configuration;
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
        public async Task<IEnumerable<CardsDto>> GetCardsByEmployeeId(string employeeId)
        {
            IEnumerable<CardsDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetCardsByEmployeeId";
                    result = await connection.QueryAsync<CardsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        
        public async Task<bool> SaveIdeaIcons(IdeaIcons ideaIcon)
        {
            try
            {
                var parameters = new
                {
                    Icon = ideaIcon.Icon,
                    Backgroundcolor=ideaIcon.Backgroundcolor,
                    Number=ideaIcon.Number,
                    Title=ideaIcon.Title
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "SaveIdeaIcons";
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
        public async Task<bool> UpdateIdeaIcons(IdeaIcons ideaIcon)
        {
            try
            {
                var parameters = new
                {
                    Id = ideaIcon.ID,
                    Icon = ideaIcon.Icon,
                    Backgroundcolor = ideaIcon.Backgroundcolor,
                    Number = ideaIcon.Number,
                    Title = ideaIcon.Title
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "UpdateIdeaIcons";
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
        public async Task<IEnumerable<IconsDto>> GetIdeaIcons()
        {
            IEnumerable<IconsDto> result;
            try
            {
                var parameters = new {  };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetIdeaIcons";
                    result = await connection.QueryAsync<IconsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
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
