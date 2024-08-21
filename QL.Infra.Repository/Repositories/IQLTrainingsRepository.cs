using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;

namespace QL.Infra.Repository.Repositories
{
    public interface IQLTrainingsRepository
    {
        Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto);
        
        Task<bool> CancelTrainingAsync(Guid trainingId);
        Task<bool> TrainingAlreadyRegistered(QLRegisterTrainingDTO dto);
        
        Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration();
        Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId);
        Task<IEnumerable<AttendanceResultDto>> MarkAttendanceAsync(List<MarkAttendance> empIds);
    }
}
