using DemoWebAPI.Services.LifeCycles;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LifeCyclesController : ControllerBase
{
    private static uint _requestCount;

    private readonly LifeCycleService _service1;
    private readonly LifeCycleService _service2;

    public LifeCyclesController(
        LifeCycleService service1,
        LifeCycleService service2)
    {
        _service1 = service1;
        _service2 = service2;

        _requestCount++;
    }

    [HttpGet]
    public IActionResult Get()
        => Ok($"""
            Request number: {_requestCount}

            Service1:
                {_service1.GetInstantiationDetails()}

            Service2:
                {_service2.GetInstantiationDetails()}
            """);
}
