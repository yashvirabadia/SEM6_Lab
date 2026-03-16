using Microsoft.AspNetCore.Mvc;

namespace RoutingPracticeWebApi.Controllers
{
    [ApiController]
    [Route("api/users")]  
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    
    public class HomeController : ControllerBase
    {
        // V1
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult Index(int id)
        {
            return Ok("Response from V1");
        }

        // V2
        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult Index1(int id)
        {
            return Ok("Response from V2");
        }
    }
}
