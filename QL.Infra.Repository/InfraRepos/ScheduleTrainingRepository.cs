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
using System.Globalization;
using QL.Infra.Models.Constants;

namespace QL.Infra.Repository.InfraRepos
{
    public class ScheduleTrainingRepository: IScheduleTraining
    {
        public IConfiguration _configuration { get; set; }
        public ScheduleTrainingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ScheduleTrainingDTO>> GetAllScheduleTrainingsAsync()
        {
            IEnumerable<ScheduleTrainingDTO> trainings;
            try
            {
                var query = @"SELECT ID, TRAININGID, TOPIC, LEARNINGOBJECTIVES, FOCUSAREAS, MODE, VENUDURATION, FACILITATOR, 
                            ISCANCELLED, STARTDATE, ENDDATE, Link, ISBUHEADAPPROVAL, ISINTERNAL, ISVirtual, CreatedDate, UpdatedDate,IsMandatory
                            FROM [dbo].[TRAININGSCHEDULE]";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    trainings = await connection.QueryAsync<ScheduleTrainingDTO>(query);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return trainings;
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

        public async Task<bool> CancelScheduledTrainingAsync(Guid trainingId)
        {
            int result;
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"UPDATE [dbo].[TRAININGSCHEDULE] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [TRAININGID] = @trainingId";

                    result = await connection.ExecuteAsync(query, new { @trainingId });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result > 0;
        }
        public async Task<bool> UpdateScheduleTrainings(ScheduleTraining scheduleTraining)
        {
            
            try
            {
                var parameters = new
                {
                    TrainingID = scheduleTraining.TrainingID,
                    Topic = scheduleTraining.Topic,
                    LearningObjectives = scheduleTraining.LearningObjectives,
                    FocusAreas = scheduleTraining.FocusAreas,
                    Mode = scheduleTraining.Mode,
                    VenuDuration = scheduleTraining.Venuduration,
                    Facilitator = scheduleTraining.Facilitator,
                    IsCancelled = (scheduleTraining.IsCancelled.ToUpper() == "YES" ? true : false), 
                    IsInternal = (scheduleTraining.IsInternal.ToUpper() == "YES" ? true : false),
                    IsBuHeadApproval = (scheduleTraining.IsBuHeadApproval.ToUpper() == "YES" ? true : false),
                    IsVirtual = (scheduleTraining.IsVirtual.ToUpper() == "YES" ? true : false),
                    StartDate = scheduleTraining.StartDate,
                    EndDate = scheduleTraining.EndDate,
                    CreatedDate = scheduleTraining.CreatedDate,
                    UpdatedDate = scheduleTraining.UpdatedDate,
                    IsMandatory = (scheduleTraining.IsMandatory.ToUpper() == "YES" ? true : false)
                };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "UpdateTrainingSchedule";
                    int result = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                    if (result == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

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
            table.Columns.Add("IsCancelled", typeof(bool));
            table.Columns.Add("StartDate", typeof(DateTime));
            table.Columns.Add("EndDate", typeof(DateTime));            
            table.Columns.Add("IsBuHeadApproval", typeof(bool));
            table.Columns.Add("IsInternal", typeof(bool));
            table.Columns.Add("IsVirtual", typeof(bool));
            table.Columns.Add("IsInternal", typeof(bool));
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("IsMandatory", typeof(bool));


            CultureInfo provider = CultureInfo.InvariantCulture;
            
            string format = "dd-MM-yyyy";
            foreach (var schedule in schedules)
            {

                DateTime startDate = DateTime.ParseExact(schedule.StartDate, format, provider);
                DateTime endDate = DateTime.ParseExact(schedule.EndDate, format, provider);
                table.Rows.Add(schedule.Topic, schedule.LearningObjectives, schedule.FocusAreas, schedule.Mode, schedule.Venuduration, schedule.Facilitator,(schedule.IsCancelled.ToUpper()=="YES"?true:false), startDate, endDate, (schedule.IsBuHeadApproval.ToUpper() == "YES" ? true : false), (schedule.IsInternal.ToUpper() == "YES" ? true : false) , (schedule.IsVirtual.ToUpper() == "YES" ? true : false), (schedule.IsMandatory.ToUpper() == "YES" ? true : false), new Guid(schedule.Id));
            }

            return table;
        }

    }
}
