using Microsoft.Extensions.Configuration;
using QL.Infra.Models.InnovateIdea;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL.Infra.Models.Dto;
using QL.Infra.Repository.Repositories;
using Dapper;
using QL.Infra.Models.Training;

namespace QL.Infra.Repository.InfraRepos
{
    public class ScheduleTrainingRepository: IScheduleTraining
    {
        public IConfiguration _configuration { get; set; }
        public ScheduleTrainingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SaveScheduleTrainings(IEnumerable<ScheduleTraining> scheduleTrainingDtos)
        {
            try
            {
                var dataTable = GetTrainingScheduleDataTable(scheduleTrainingDtos);
                var sqlParameters = new[]
                {
                new SqlParameter("@TrainingSchedules", SqlDbType.Structured)
                {
                TypeName = "dbo.TrainingScheduleType",
                Value = dataTable
                }
                };
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TrainingSchedules", dataTable.AsTableValuedParameter("TrainingScheduleType"));

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "SaveScheduleTraining";                
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
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTrainingScheduleDataTable(IEnumerable<ScheduleTraining> schedules)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Topic", typeof(string));
            table.Columns.Add("LearningObjectives", typeof(string));
            table.Columns.Add("ForcusAreas", typeof(string));
            table.Columns.Add("Mode", typeof(string));
            table.Columns.Add("VenuDuration", typeof(string));
            table.Columns.Add("Facilitator", typeof(string));
            table.Columns.Add("IsAttended", typeof(bool));
            table.Columns.Add("StartDate", typeof(DateTime));
            table.Columns.Add("EndDate", typeof(DateTime));
            table.Columns.Add("Trcode", typeof(int));

            foreach (var schedule in schedules)
            {
                table.Rows.Add(schedule.Topic, schedule.LearningObjectives, schedule.FocusAreas, schedule.Mode, schedule.Venuduration, schedule.Facilitator, schedule.IsAttended, schedule.StartDate, schedule.EndDate, schedule.TrCode);
            }

            return table;
        }

    }
}
