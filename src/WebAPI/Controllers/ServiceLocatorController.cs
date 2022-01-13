using System;
using DemoWebAPI.Services.ServiceLocators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebAPI.Controllers;

// Avoid using the service locator pattern
[ApiController]
[Route("[controller]")]
public class ServiceLocatorController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceLocatorController(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    [HttpGet("{min:int}/{max:int}")]
    public IActionResult Get(int min, int max)
    {
        var service = _serviceProvider.GetRequiredService<ILocatorService>();
        var value = service.GetRadom(min, max);

        return Ok(value);
    }
}
