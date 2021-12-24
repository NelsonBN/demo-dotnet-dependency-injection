using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Services.Examples;

namespace WebAPI.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    private IExampleService _service;

    protected IExampleService Service
            => _service ??= HttpContext.RequestServices
                    .GetService<IExampleService>();
}
