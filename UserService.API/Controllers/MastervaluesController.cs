using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Models.InnovateIdea;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastervaluesController : ControllerBase
    {
        private readonly ILogger<MastervaluesController> _logger;
        private IMasterInfomation _masterinforepo;

        public MastervaluesController(IMasterInfomation masterinforepo, ILogger<MastervaluesController> logger)
        {
            _logger = logger;
            _masterinforepo = masterinforepo;
        }

        [HttpGet("GetAppName")]
        public async Task<IActionResult> GetAppName()
        {
            var data = await _masterinforepo.GetAppName();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("GetRequestType")]
        public async Task<IActionResult> GetRequestType()
        {
            var data = await _masterinforepo.GetRequestType();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            var data = await _masterinforepo.GetStatus();
            if (data == null)
            {
                return Ok("No Records Found");
            }
            return Ok(data);
        }

        [HttpGet("GetIdeaIcons")]
        public async Task<IEnumerable<IconsDto>> GetIdeaIcons()
        {
            return await _masterinforepo.GetIdeaIcons();
        }

        [HttpPost("SaveIdeaIcons")]
        public async Task<bool> SaveIdeaIcons(IdeaIcons ideaIcon)
        {
            return await _masterinforepo.SaveIdeaIcons(ideaIcon);
        }

        [HttpPut("UpdateIdeaIcons")]
        public async Task<bool> UpdateIdeaIcons(IdeaIcons ideaIcon)
        {
            return await _masterinforepo.UpdateIdeaIcons(ideaIcon);
        }
    }
}
