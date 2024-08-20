﻿using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLTrainingsController : ControllerBase
    {
        private readonly ILogger<QLTrainingsController> _logger;
        private IQLTrainingsRepository _qlTrainingsRepository;

        public QLTrainingsController(IQLTrainingsRepository qlTrainingsRepository, ILogger<QLTrainingsController> logger)
        {
            _logger = logger;
            _qlTrainingsRepository = qlTrainingsRepository;
        }

        [HttpGet("GetAllScheduleTrainings")]
        public async Task<IEnumerable<ScheduleTrainingDTO>> GetAllScheduleTrainingsAsync()
        {
            return await _qlTrainingsRepository.GetAllScheduleTrainingsAsync();
        }

        [HttpPost("RegisterTraining")]
        public async Task<IActionResult> RegisterTraining([FromBody] QLRegisterTrainingDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid details.");
            }

            var exists = await _qlTrainingsRepository.TrainingAlreadyRegistered(model);

            if (exists)
            {
                return Conflict($" Training {model.TrainingScheduleId} already registered with Employee {model.EmpId}");
            }

            var result = await _qlTrainingsRepository.RegisterTrainingAsync(model);
            
            return Ok(new { Id = result, Message = "Training registered successfully." });
        }

        [HttpPut("CancelTraining")]
        public async Task<IActionResult> CancelTraining(Guid trainingId)
        {
            var result = await _qlTrainingsRepository.CancelTrainingAsync(trainingId);
            if (result)
            {
                return Ok($" Training Id {trainingId} cancelled successfully.");
            }

            return NotFound("Training not found.");
        }

        [HttpPut("CancelScheduledTraining")]
        public async Task<IActionResult> CancelScheduledTraining(Guid trainingId)
        {
            var result = await _qlTrainingsRepository.CancelScheduledTrainingAsync(trainingId);
            if (result)
            {
                return Ok($" Scheduled Training Id {trainingId} cancelled successfully.");
            }

            return NotFound("Training not found.");
        }
        
        [HttpGet("GetTrainingsforRegistration")]
        public async Task<IEnumerable<QLTrainingsDto>> GetTrainingsforRegistration()
        {
            return await _qlTrainingsRepository.GetTrainingsforRegistration();
        }
        [HttpGet("GetRegisteredTrainingsByEmployee")]
        public async Task<IEnumerable<QLTrainingRegistrationDto>> GetRegisteredTrainingsByEmployee(string employeeId)
        {
            return await _qlTrainingsRepository.GetRegisteredTrainingsByEmployee(employeeId);
        }
    }
}
