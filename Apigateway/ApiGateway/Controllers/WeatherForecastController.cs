using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class WeatherForecastController : ControllerBase
    {
        [Route("/Fire")]
        [HttpGet]
        public IActionResult GetFire()
        {
            return Ok();
        }
    }
}