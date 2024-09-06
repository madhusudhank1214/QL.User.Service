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
                                  (EmpMail, ManagerMail, TrainingScheduleId, EmpName, ManagerName, RegisteredDate,BuHeadMail) 
                                  VALUES 
                                  (@EmpMail, @ManagerMail, @TrainingScheduleId, @EmpName, @ManagerName, GETDATE(),@BuHeadMail)
                                  
                                  SELECT CAST(SCOPE_IDENTITY() as int)";

                    id = await connection.ExecuteScalarAsync<int>(query, new
                    {
                        dto.EmpMail,
                        dto.ManagerMail,
                        dto.TrainingScheduleId,
                        dto.EmpName,
                        dto.ManagerName,
                        dto.BuHeadMail
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        public async Task<bool> CancelRegisterTrainingAsync(Guid trainingScheduleId, string empMail)
        {

            int result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var record = @"SELECT COUNT(*) FROM [dbo].[REGISTERTRAINING] WHERE [EmpMail] = @empMail AND [TrainingScheduleId] = @trainingScheduleId";
                    var exist = await connection.QuerySingleOrDefaultAsync<bool>(record, new { empMail, trainingScheduleId });

                    if (exist)
                    {
                        var query = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsCancelled] = 1, [UpdatedDate] = GETDATE()
                               WHERE [EmpMail] = @empMail AND [TrainingScheduleId] = @trainingScheduleId";

                        result = await connection.ExecuteAsync(query, new { empMail, trainingScheduleId });
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
                    var query = @"SELECT COUNT(*) FROM [dbo].[REGISTERTRAINING] WHERE [EmpMail] = @empMail AND [TrainingScheduleId] = @trainingScheduleId";

                    result = await connection.QuerySingleOrDefaultAsync<bool>(query, new
                    {
                        dto.EmpMail,
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


                var query = "SELECT TRAININGID,TOPIC,LEARNINGOBJECTIVES as focusareas,FOCUSAREAS,MODE,VENUDURATION,FACILITATOR as facilitator,ISCANCELLED,STARTDATE as StartDate,ENDDATE as EndDate,Mode,ISBUHEADAPPROVAL,ISINTERNAL,ISVirtual,IsMandatory FROM TRAININGSCHEDULE;";
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

        public async Task<IEnumerable<QLTrainingsDto>> GetMandatoryTrainings()
        {
            IEnumerable<QLTrainingsDto> result;
            try
            {


                var query = "SELECT TRAININGID,TOPIC,LEARNINGOBJECTIVES as focusareas,FOCUSAREAS,MODE,VENUDURATION,FACILITATOR as facilitator,ISCANCELLED,STARTDATE as StartDate,ENDDATE as EndDate,Mode,ISBUHEADAPPROVAL,ISINTERNAL,ISVirtual,IsMandatory FROM TRAININGSCHEDULE where IsMandatory=1;";
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
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeMail)
        {
            IEnumerable<QLTrainingRegistrationDto> result;
            try
            {
                var parameters = new { EmployeeMail = employeeMail };
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
                    attendanceTable.Columns.Add("empmail", typeof(string));
                    attendanceTable.Columns.Add("isattended", typeof(bool));
                    attendanceTable.Columns.Add("trainingscheduleid", typeof(Guid));

                    foreach (var emp in employeeAttendances)
                    {
                        attendanceTable.Rows.Add(emp.empMail, emp.isAttended, emp.trainingScheduleId);
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
                    var spName = "CompletedTrainingsDetails";

                    result = await connection.QueryAsync<CompletedTrainingsDTO>(spName, commandType: CommandType.StoredProcedure);
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
                    var spName = "GetUpcomingTrainingsDetails";

                    result = await connection.QueryAsync<UpcomingTrainingsDTO>(spName, commandType: CommandType.StoredProcedure);
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
                    var query = @"SELECT EmpMail, EmpName, IsAttended
                                FROM DBO.REGISTERTRAINING 
                                WHERE TrainingScheduleId = @trainingId";

                    result = await connection.QueryAsync<EmployeesRegisteredToTraining>(query, new { @trainingId });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<OptedTrainingsDTO>> OptedTrainings(string employeeMail)
        {
            IEnumerable<OptedTrainingsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new { EmployeeMail = employeeMail };
                    var spName = "OptedTrainings";
                    result = await connection.QueryAsync<OptedTrainingsDTO>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<bool> ManagerApproval(Guid trainingScheduleId)
        {
            bool result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"select * from [dbo].[REGISTERTRAINING] where [TrainingScheduleId] = @trainingScheduleId";
                    var training = await connection.QuerySingleOrDefaultAsync(query,new { trainingScheduleId });
                    if(training != null)
                    {
                        var updateQuery = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsManagerApproved] = 1
                               WHERE [TrainingScheduleId] = @trainingScheduleId";

                        var rowAffected = await connection.ExecuteAsync(updateQuery, new { trainingScheduleId });
                        return result = rowAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<bool> BuHeadApproval(Guid trainingScheduleId)
        {
            bool result;
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = @"select * from [dbo].[REGISTERTRAINING] where [TrainingScheduleId] = @trainingScheduleId";
                    var training = await connection.QuerySingleOrDefaultAsync(query, new { trainingScheduleId });
                    if (training != null)
                    {
                        var updateQuery = @"UPDATE [dbo].[REGISTERTRAINING] 
                               SET [IsBuHeadApproved] = 1
                               WHERE [TrainingScheduleId] = @trainingScheduleId";

                        var rowAffected = await connection.ExecuteAsync(updateQuery, new { trainingScheduleId });
                        return result = rowAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForManager(string managerMail)
        {
            IEnumerable<PendingApprovalsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new { IsManager = true, Email = managerMail };
                    var spName = "GetPendingApprovals";
                    result = await connection.QueryAsync<PendingApprovalsDTO>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForBUHead()
        {
            IEnumerable<PendingApprovalsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new { IsManager = false };
                    var spName = "GetPendingApprovals";
                    result = await connection.QueryAsync<PendingApprovalsDTO>(spName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainingsByEmployee(string empMail)
        {
            IEnumerable<CompletedTrainingsDTO> result;

            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new { EmployeeMail = empMail };
                    var spName = "CompletedTrainingsByEmployeeDetails";

                    result = await connection.QueryAsync<CompletedTrainingsDTO>(spName, parameters, commandType: CommandType.StoredProcedure);
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

