using System;
using DemoWebAPI.Services.DelegateFunc;
using DemoWebAPI.Services.DelegateFuncs;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DelegateController : ControllerBase
{
    private readonly Func<string, ICountryService> _countryService;

    public DelegateController(Func<string, ICountryService> countryService)
        => _countryService = countryService;

    [HttpGet("{countryCode}")]
    public IActionResult Get(string countryCode)
    {
        var service = _countryService(countryCode);

        return service == null ?
            NotFound("Country not found") :
            Ok(service.GetCapital());
    }


    [HttpGet("sum/{x:int}/{y:int}")]
    public IActionResult Get(
        [FromServices] SumFunc sumFunc,
        [FromRoute] int x,
        [FromRoute] int y)
    => Ok(sumFunc(x, y));
}
