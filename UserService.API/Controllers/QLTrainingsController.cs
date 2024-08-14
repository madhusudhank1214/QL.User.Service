using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLTrainingsController : ControllerBase
    {
        private readonly ILogger<QLTrainingsController> _logger;
        private IQLTrainingsRepository _traingsrepo;

        public QLTrainingsController(IQLTrainingsRepository traingsrepo, ILogger<QLTrainingsController> logger)
        {
            _logger = logger;
            _traingsrepo = traingsrepo;
        }
        [HttpGet("GetAllTrainingSchedule")]
        public async Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration()
        {
            return await _traingsrepo.GetTrainingsforRegistration();
        }
        [HttpGet("GetRegisteredTrainingsByEmployee")]
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId)
        {
            return await _traingsrepo.GetRegisteredTrainingsByEmployee(employeeId);
        }
    }
}
