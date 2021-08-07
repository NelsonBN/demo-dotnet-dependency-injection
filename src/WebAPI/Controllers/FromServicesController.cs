using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.PropertyInjections;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FromServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]IPropertyService services)
        {
            return this.Ok(services.GetDateTime());
        }
    }
}