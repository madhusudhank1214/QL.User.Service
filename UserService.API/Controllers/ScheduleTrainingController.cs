using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Training;
using QL.Infra.Repository.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using QL.Infra.Repository.InfraRepos;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTrainingController: ControllerBase
    {
        private readonly IScheduleTraining _scheduleTraining;
        private readonly ILogger<ScheduleTrainingController> _logger;
        private readonly IValidator<List<ScheduleTraining>> _validator;
        public ScheduleTrainingController(IScheduleTraining scheduleTraining, ILogger<ScheduleTrainingController> logger, IValidator<List<ScheduleTraining>> validator)
        {
            _scheduleTraining = scheduleTraining;
            _logger = logger;
            _validator = validator;
        }

        [HttpGet("GetAllScheduleTrainings")]
        public async Task<IEnumerable<ScheduleTrainingDTO>> GetAllScheduleTrainingsAsync()
        {
            return await _scheduleTraining.GetAllScheduleTrainingsAsync();
        }

        [HttpPost("SaveScheduleTrainings")]
        public async Task<IActionResult> SaveScheduleTrainings(List<ScheduleTraining> scheduleTraining)
        {
            
            try
            {
                FluentValidation.Results.ValidationResult result = _validator.Validate(scheduleTraining);

                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
                return Ok(await _scheduleTraining.SaveScheduleTrainings(scheduleTraining));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateScheduleTrainings")]
        public async Task<IActionResult> UpdateScheduleTrainings(ScheduleTraining scheduleTraining)
        {

            try
            {

                if (scheduleTraining.TrainingID==Guid.Empty)
                {
                    return BadRequest("TrainingID is Empty");
                }
                return Ok(await _scheduleTraining.UpdateScheduleTrainings(scheduleTraining));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("CancelScheduledTraining")]
        public async Task<IActionResult> CancelScheduledTraining(Guid trainingId)
        {
            var result = await _scheduleTraining.CancelScheduledTrainingAsync(trainingId);
            if (result)
            {
                return Ok($" Scheduled Training Id {trainingId} cancelled successfully.");
            }

            return NotFound("Training not found.");
        }
    }
}
