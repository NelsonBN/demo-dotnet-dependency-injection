using DemoWebAPI.Services.Generics;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenericController : ControllerBase
{
    private readonly IGenericService<Car> _carService;
    private readonly IGenericService<Motorcycle> _motorcycleService;

    public GenericController(
        IGenericService<Car> carService,
        IGenericService<Motorcycle> motorcycleService)
    {
        _carService = carService;
        _motorcycleService = motorcycleService;
    }

    [HttpGet(nameof(Car))]
    public IActionResult GetCar()
        => Ok(_carService.GetInstanceType(new Car()));

    [HttpGet(nameof(Motorcycle))]
    public IActionResult GetMotorcycle()
        => Ok(_motorcycleService.GetInstanceType(new Motorcycle()));
}
