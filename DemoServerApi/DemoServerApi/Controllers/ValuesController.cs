using Microsoft.AspNetCore.Mvc;

namespace DemoServerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello from API!" });
        }
    }

}
