using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface IScheduleTraining
    {
        Task<bool> SaveScheduleTrainings(IEnumerable<ScheduleTraining> scheduleTrainingDtos);
        Task<bool> UpdateScheduleTrainings(ScheduleTraining scheduleTrainingDto);
    }
}
