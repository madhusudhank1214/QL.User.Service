using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IEmployeeWFHRequest _empWFHRequest;

        public UsersController(IEmployeeWFHRequest empWFHRequest,ILogger<UsersController> logger)
        {
            _logger = logger;
            _empWFHRequest = empWFHRequest;
        }
        [HttpGet]
        public string Get()
        {
            return "Welcome to User World";
        }
        [HttpGet("GetAllEmployees")]
        public IEnumerable<QLEmployee> GetAllEmployees()
        {
            List<QLEmployee> _lstqLEmployees = [];
            _lstqLEmployees = _empWFHRequest.GetAllEmployees().ToList(); 
            return _lstqLEmployees;
        }
    }
}
