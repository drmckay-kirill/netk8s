using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult HelloWorld()
        {
            return Ok("Hello, world!");
        }
    }
}