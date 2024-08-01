using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class InnovateIdeasController : ControllerBase
    {
        private readonly ILogger<InnovateIdeasController> _logger;
        private  IInnovateideaRepository _idearepo;

        public InnovateIdeasController(IInnovateideaRepository idearepo, ILogger<InnovateIdeasController> logger)
        {
            _logger = logger;
            _idearepo = idearepo;
        }
        [HttpGet("GetAllQLInnovativeIdeas")]
        public async Task<IEnumerable<QLIdeaTrackerDto>> GetAllQLInnovativeIdeas()
        {
            return await _idearepo.GetAllQLInnovativeIdeas();
        }
        [HttpGet("GetQLIdeasByEmployee")]
        public async Task<IEnumerable<QLIdeaTrackerDto>> GetQLIdeasByEmployee(string employeeId)
        {
            return await _idearepo.GetQLIdeasByEmployee(employeeId);
        }

        [HttpGet("GetQLIdeaDetails")]
        public async Task<IActionResult> GetQLIdeaDetails()
        {
            var data = await _idearepo.GetQLIdeaDetails();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpPost("saveIdeaTracker")]
        public async Task<bool> SaveIdeaTracker(IdeaTracker ideaTracker)
        {
            return await _idearepo.SaveIdeaTracker(ideaTracker);
        }

    }
}
