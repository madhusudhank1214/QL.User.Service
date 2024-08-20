using Dapper;
using Microsoft.Extensions.Configuration;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace QL.Infra.Repository.InfraRepos
{
    public class QLTrainingsRepository : IQLTrainingsRepository
    {        

        private readonly IConfiguration configuration;

        public QLTrainingsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ScheduleTrainingDTO>> GetAllScheduleTrainingsAsync()
        {
            IEnumerable<ScheduleTrainingDTO> trainings;
            try
            {
                var query = @"SELECT ID, TRAININGID, TOPIC, LEARNINGOBJECTIVES, FOCUSAREAS, MODE, VENUDURATION, FACILITATOR, 
                            ISCANCELLED, STARTDATE, ENDDATE, Link, ISBUHEADAPPROVAL, ISINTERNAL, ISVirtual, CreatedDate, UpdatedDate
                            FROM [dbo].[TRAININGSCHEDULE]";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    trainings = await connection.QueryAsync<ScheduleTrainingDTO>(query);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return trainings;
        }

        public async Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto)
        {
            var model = new QLRegisterTraining
            {
                EmpId = dto.EmpId,
                ManagerId = dto.ManagerId,
                TrainingScheduleId = Guid.NewGuid(),
                RegisteredDate = DateTime.Now,
                UpdatedDate = dto.UpdatedDate,
                IsAttended = dto.IsAttended,
                IsCancelled = dto.IsCancelled
            };

            int id;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = @" INSERT INTO [dbo].[REGISTERTRAINING] 
                                  (EmpId, ManagerId, TrainingScheduleId, RegisteredDate, UpdatedDate, IsAttended, IsCancelled) 
                                  VALUES 
                                  (@EmpId, @ManagerId, @TrainingScheduleId, @RegisteredDate, @UpdatedDate, @IsAttended, @IsCancelled);
                                  SELECT CAST(SCOPE_IDENTITY() as int);";

                    id = await connection.ExecuteScalarAsync<int>(query, new
                    {
                        model.EmpId,
                        model.ManagerId,
                        model.TrainingScheduleId,
                        model.RegisteredDate,
                        model.UpdatedDate,
                        model.IsAttended,
                        model.IsCancelled
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return id;
        }

        public async Task<bool> CancelTrainingAsync(int id)
        {
            int result;
            try
            {                
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [ID] = @Id";

                    result = await connection.ExecuteAsync(query, new { Id = id });

                    return result > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CancelScheduledTrainingAsync(int id)
        {
            int result;
            try
            {                
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"UPDATE [dbo].[TRAININGSCHEDULE] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [ID] = @Id";
                    
                    result = await connection.ExecuteAsync(query, new { Id = id });

                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> TrainingAlreadyRegistered(QLRegisterTrainingDTO dto)
        {
            bool result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"SELECT COUNT(*) FROM [dbo].[REGISTERTRAINING] WHERE [EmpId] = @empId AND [TrainingScheduleId] = @trainingScheduleId";

                    result = await connection.QuerySingleOrDefaultAsync<bool>(query, new
                    {
                        dto.EmpId,
                        dto.TrainingScheduleId
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }        

        public async Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration()
        {
            IEnumerable<QLTrainingsDto> result;
            try
            {
                var parameters = new { };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetTrainingsforRegistration";
                    result = await connection.QueryAsync<QLTrainingsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId)
        {
            IEnumerable<QLTrainingRegistrationDto> result;
            try
            {
                var parameters = new { EmployeeId = employeeId };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "GetRegisteredTrainingsByEmployeeId";
                    result = await connection.QueryAsync<QLTrainingRegistrationDto>(spName, parameters, commandType: CommandType.StoredProcedure);
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
