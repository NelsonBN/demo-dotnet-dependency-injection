using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAPI.Services.ServiceLocators;

namespace WebAPI.Controllers
{
    // Avoid using the service locator pattern
    [ApiController]
    [Route("[controller]")]
    public class ServiceLocatorController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceLocatorController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        [HttpGet("{min:int}/{max:int}")]
        public IActionResult Get(int min, int max)
        {

            var service = this._serviceProvider.GetRequiredService<ILocatorService>();
            var value = service.GetRadom(min, max);

            return this.Ok(value);
        }
    }
}