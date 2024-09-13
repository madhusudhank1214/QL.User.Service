using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;

namespace QL.Infra.Repository.Repositories
{
    public interface IQLTrainingsRepository
    {
        Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto);
        
        Task<string> CancelRegisterTrainingAsync(Guid trainingId, string empId);
        Task<bool> TrainingAlreadyRegistered(QLRegisterTrainingDTO dto);
        
        Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration();
        Task<IEnumerable<QLRegisterTrainingDto>> GetMandatoryTrainings(string empMail);
        Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId);
        Task<IEnumerable<AttendanceResultDto>> MarkAttendanceAsync(List<MarkAttendance> empIds);
        Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainings();
        Task<IEnumerable<UpcomingTrainingsDTO>> UpcomingTrainings();

        Task<IEnumerable<QLTrainingsDto>> FilterTraining(FilterRequest filterRequest);
        Task<IEnumerable<EmployeesRegisteredToTraining>> GetEmployeesRegisteredToTraining(Guid trainingId);
        Task<IEnumerable<OptedTrainingsDTO>> OptedTrainings(string employeeMail);
        Task<bool> ManagerApproval(Guid trainingScheduleId,string empMail,string? buHeadMail);
        Task<bool> ManagerReject(Guid trainingScheduleId, string empMail, string? buHeadMail);
        Task<bool> BuHeadApproval(Guid trainingScheduleId, string empMail, string? buHeadMail);
        Task<bool> BuHeadReject(Guid trainingScheduleId, string empMail, string? buHeadMail);
        Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForManager(string managerMail);
        Task<IEnumerable<PendingApprovalsDTO>> PendingApprovalsForBUHead();
        Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainingsByEmployee(string empMail);
        Task<IEnumerable<TrainingAttendanceRecords>> InsertTrainingAttendanceRecords(TrainingAttendanceRecords request);
        Task<IEnumerable<TrainingAttendanceRecordsDto>> UpdateTrainingAttendanceRecords(TrainingAttendanceRecordsDto request);
        Task<IEnumerable<BuHeadDetailDto>> GetBuHeadDetails();
    }
}
