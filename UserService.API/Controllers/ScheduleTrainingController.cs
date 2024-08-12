using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTrainingController: ControllerBase
    {
        private readonly IScheduleTraining _scheduleTraining;
        private readonly ILogger<ScheduleTrainingController> _logger;
        public ScheduleTrainingController(IScheduleTraining scheduleTraining, ILogger<ScheduleTrainingController> logger)
        {
            _scheduleTraining = scheduleTraining;
            _logger = logger;
        }
        [HttpPost("SaveScheduleTrainings")]
        public async Task<bool> SaveScheduleTrainings(IEnumerable<ScheduleTraining> scheduleTraining)
        {
            var save=await _scheduleTraining.SaveScheduleTrainings(scheduleTraining);
            return true;
        }
    }
}
