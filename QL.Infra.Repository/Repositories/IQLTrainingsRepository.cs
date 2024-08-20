using QL.Infra.Models.Dto;
using QL.Infra.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface IQLTrainingsRepository
    {
        Task<int> RegisterTrainingAsync(QLRegisterTrainingDTO dto);
        Task<IEnumerable<ScheduleTrainingDTO>> GetAllScheduleTrainingsAsync();
        Task<bool> CancelTrainingAsync(int id);
        Task<bool> TrainingAlreadyRegistered(QLRegisterTrainingDTO dto);
        Task<bool> CancelScheduledTrainingAsync(int id);
        Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration();
        Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId);
    }
}
