using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;

namespace QL.Infra.Repository.Repositories
{
    public interface IQLTrainingsRepository
    {
        Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto);
        
        Task<bool> CancelRegisterTrainingAsync(Guid trainingId, string empId);
        Task<bool> TrainingAlreadyRegistered(QLRegisterTrainingDTO dto);
        
        Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration();
        Task<IEnumerable<QLTrainingsDto>> GetMandatoryTrainings();
        Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId);
        Task<IEnumerable<AttendanceResultDto>> MarkAttendanceAsync(List<MarkAttendance> empIds);
        Task<IEnumerable<CompletedTrainingsDTO>> CompletedTrainings();
        Task<IEnumerable<UpcomingTrainingsDTO>> UpcomingTrainings();

        Task<IEnumerable<QLTrainingsDto>> FilterTraining(FilterRequest filterRequest);
        Task<IEnumerable<EmployeesRegisteredToTraining>> GetEmployeesRegisteredToTraining(Guid trainingId);
        Task<IEnumerable<OptedTrainingsDTO>> OptedTrainings(string employeeMail);
    }
}
