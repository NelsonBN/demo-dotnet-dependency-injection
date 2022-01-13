using DemoWebAPI.Services.Examples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebAPI.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    private IExampleService _service;

    protected IExampleService Service
            => _service ??= HttpContext.RequestServices
                    .GetService<IExampleService>();
}
