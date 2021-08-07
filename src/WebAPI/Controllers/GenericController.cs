using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Generics;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController : ControllerBase
    {
        private readonly IGenericService<Car> _carService;
        private readonly IGenericService<Motorcycle> _motorcycleService;

        public GenericController(
            IGenericService<Car> carService,
            IGenericService<Motorcycle> motorcycleService
        )
        {
            this._carService = carService;
            this._motorcycleService = motorcycleService;
        }

        [HttpGet(nameof(Car))]
        public IActionResult GetCar()
        {
            return this.Ok(this._carService.GetInstanceType(new Car()));
        }

        [HttpGet(nameof(Motorcycle))]
        public IActionResult GetMotorcycle()
        {
            return this.Ok(this._motorcycleService.GetInstanceType(new Motorcycle()));
        }
    }
}