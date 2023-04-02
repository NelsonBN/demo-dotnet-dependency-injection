using System.Collections.Generic;
using System.Text;
using DemoWebAPI.Services.MultiInjections;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MultiInjectionController : ControllerBase
{
    private readonly IEnumerable<IMultiInjection> _services;

    public MultiInjectionController(IEnumerable<IMultiInjection> services) => _services = services;

    [HttpGet]
    public IActionResult Get()
    {
        var sb = new StringBuilder();

        foreach(var service in _services)
        {
            sb.AppendLine(service.GetServiceName());
        }

        return Ok(sb.ToString());
    }
}
