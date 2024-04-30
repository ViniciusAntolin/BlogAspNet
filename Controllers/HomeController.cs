using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("v1")]
        public IActionResult Get() => Ok(new {versao = "1.1.0"});
        
        [HttpGet("v2")]
        public IActionResult Getv2() => Ok(new {versao = "1.0.0"});
    }
}
