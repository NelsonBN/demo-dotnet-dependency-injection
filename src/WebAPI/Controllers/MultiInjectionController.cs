using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Services.MultiInjections;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiInjectionController : ControllerBase
    {
        private readonly Func<string, ICountryService> _countryService;

        public MultiInjectionController(
            Func<string, ICountryService> countryService
        )
        {
            this._countryService = countryService;
        }

        [HttpGet("{countryCode}")]
        public IActionResult Get(string countryCode)
        {
            var service = this._countryService(countryCode);

            if(service == null)
            {
                return this.NotFound("Country not found");
            }

            return this.Ok(service.GetCapital());
        }
    }
}