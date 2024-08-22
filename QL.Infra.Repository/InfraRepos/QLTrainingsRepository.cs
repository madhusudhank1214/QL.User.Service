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
        
        public async Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto)
        {
            int id;

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

        public async Task<bool> CancelTrainingAsync(Guid trainingId)
        {
            int result;
            try
            {                
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [TrainingScheduleId] = @trainingId";

                    result = await connection.ExecuteAsync(query, new { @trainingId });                    
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result > 0;
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
                

                var query = "SELECT TRAININGID,TOPIC,LEARNINGOBJECTIVES as focusareas,FOCUSAREAS,MODE,VENUDURATION,FACILITATOR as facilitator,ISCANCELLED,STARTDATE as StartDate,ENDDATE as EndDate,Mode,ISBUHEADAPPROVAL,ISINTERNAL,ISVirtual FROM TRAININGSCHEDULE;";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    
                    var trainings = await connection.QueryAsync<QLTrainingsDto>(query);
                    return trainings;
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

        public async Task<IEnumerable<AttendanceResultDto>> MarkAttendanceAsync(List<MarkAttendance> employeeAttendances)
        {
            IEnumerable<AttendanceResultDto> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var attendanceTable = new DataTable();
                    attendanceTable.Columns.Add("empid", typeof(string));
                    attendanceTable.Columns.Add("isattended", typeof(bool));
                    attendanceTable.Columns.Add("trainingscheduleid", typeof(Guid));

                    foreach (var emp in employeeAttendances)
                    {
                        attendanceTable.Rows.Add(emp.empId, emp.isAttended, emp.trainingScheduleId);
                    }

                    var parameters = new { AttendanceList = attendanceTable };
                    var spName = "MarkAttendance";

                    result = await connection.QueryAsync<AttendanceResultDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainings()
        {
            IEnumerable<CompletedTrainingsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @" SELECT TOPIC, ENDDATE AS CompletedOn FROM [dbo].[TRAININGSCHEDULE]
                           WHERE Enddate >= GETDATE() ORDER BY CompletedOn";

                    result = await connection.QueryAsync<CompletedTrainingsDTO>(query);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<UpcomingTrainingsDTO>> UpcomingTrainings()
        {
            IEnumerable<UpcomingTrainingsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @" SELECT TOPIC, STARTDATE FROM [dbo].[TRAININGSCHEDULE]
                            WHERE STARTDATE > GETDATE() ORDER BY STARTDATE";

                    result = await connection.QueryAsync<UpcomingTrainingsDTO>(query);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}

