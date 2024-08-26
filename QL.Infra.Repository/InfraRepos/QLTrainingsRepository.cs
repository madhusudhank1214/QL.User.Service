using Dapper;
using Microsoft.Extensions.Configuration;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;
using System.Data.SqlClient;
using System.Data;

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

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = @" INSERT INTO [dbo].[REGISTERTRAINING] 
                                  (EmpId, ManagerId, TrainingScheduleId, RegisteredDate) 
                                  VALUES 
                                  (@EmpId, @ManagerId, @TrainingScheduleId, GETDATE())
                                  
                                  SELECT CAST(SCOPE_IDENTITY() as int)";

                    id = await connection.ExecuteScalarAsync<int>(query, new
                    {
                        dto.EmpId,
                        dto.ManagerId,
                        dto.TrainingScheduleId
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        public async Task<bool> CancelRegisterTrainingAsync(Guid trainingScheduleId, string empId)
        {

            int result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var record = @"SELECT COUNT(*) FROM [dbo].[REGISTERTRAINING] WHERE [EmpId] = @empId AND [TrainingScheduleId] = @trainingScheduleId";
                    var exist = await connection.QuerySingleOrDefaultAsync<bool>(record, new { empId, trainingScheduleId });

                    if (exist)
                    {
                        var query = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [EmpId] = @empId AND [TrainingScheduleId] = @trainingScheduleId";

                        result = await connection.ExecuteAsync(query, new { empId, trainingScheduleId });
                        return result > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return false;
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
                    var query = @" SELECT TOPIC, TRAININGID, ENDDATE AS CompletedOn FROM [dbo].[TRAININGSCHEDULE]
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

        public async Task<IEnumerable<QLTrainingsDto>> FilterTraining(FilterRequest filterRequest)
        {
            IEnumerable<QLTrainingsDto> result;

            try
            {
                var parameters = new
                {
                    StartDate= filterRequest.StartDate,
                    EndDate= filterRequest.EndDate,
                    Topic= filterRequest.Topic,
                    Facilitator= filterRequest.Facilitator,
                    IsInternal= filterRequest.IsInternal,
                    IsVirtual= filterRequest.IsVirtual,
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var spName = "TrainingFilter";
                    result = await connection.QueryAsync<QLTrainingsDto>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<EmployeesRegisteredToTraining>> GetEmployeesRegisteredToTraining(Guid trainingId)
        {
            IEnumerable<EmployeesRegisteredToTraining> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"SELECT R.EmpId, Q.Name, R.IsAttended
                               FROM DBO.REGISTERTRAINING AS R
                               JOIN DBO.QLEmployees AS Q ON R.EmpId = Q.EmpId
                               WHERE R.TrainingScheduleId = @trainingId";

                    result = await connection.QueryAsync<EmployeesRegisteredToTraining>(query, new { @trainingId });
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

