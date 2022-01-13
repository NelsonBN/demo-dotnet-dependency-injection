using DemoWebAPI.Services.PropertyInjections;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FromServicesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromServices] IPropertyService services)
        => Ok(services.GetDateTime());
}
