using System;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private string HostnameEnvironmentVariable => "HOSTNAME";

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult HelloWorld()
        {
            var hostname = Environment.GetEnvironmentVariable(HostnameEnvironmentVariable); 
            return Ok(hostname ?? "Hostname not found");
        }
    }
}