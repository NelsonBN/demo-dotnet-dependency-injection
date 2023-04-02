using System;
using DemoWebAPI.Services.DelegateFuncs;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DelegateFuncsController : ControllerBase
{
    private readonly Func<string, ICountryService> _countryService;

    public DelegateFuncsController(Func<string, ICountryService> countryService)
        => _countryService = countryService;

    [HttpGet("{countryCode}")]
    public IActionResult Get(string countryCode)
    {
        var service = _countryService(countryCode);

        return service == null ?
            NotFound("Country not found") :
            Ok(service.GetCapital());
    }
}
