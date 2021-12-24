using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Services.MultiInjections;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MultiInjectionController : ControllerBase
{
    private readonly Func<string, ICountryService> _countryService;

    public MultiInjectionController(
        Func<string, ICountryService> countryService
    ) => _countryService = countryService;

    [HttpGet("{countryCode}")]
    public IActionResult Get(string countryCode)
    {
        var service = _countryService(countryCode);

        return service == null ?
            NotFound("Country not found") :
            Ok(service.GetCapital());
    }
}
