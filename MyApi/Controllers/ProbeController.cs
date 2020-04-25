using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbeController : ControllerBase
    {
        [HttpGet("live")]
        public ActionResult LivenessProbe()
        {
            return Ok();
        }
    }
}