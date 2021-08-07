﻿using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.LifeCycles;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifeCyclesController : ControllerBase
    {
        private static uint _requestCount;

        private readonly LifeCycleService _service1;
        private readonly LifeCycleService _service2;

        public LifeCyclesController(
            LifeCycleService service1,
            LifeCycleService service2
        )
        {
            this._service1 = service1;
            this._service2 = service2;

            _requestCount++;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(
                $"Request number: {_requestCount}" +
                
                $"{System.Environment.NewLine}" +
                $"{System.Environment.NewLine}" +
                
                $"Service1: {System.Environment.NewLine}{this._service1.GetInstantiationDetails()}" +
                
                $"{System.Environment.NewLine}" +
                $"{System.Environment.NewLine}" +
                
                $"Service2: {System.Environment.NewLine}{this._service2.GetInstantiationDetails()}"
            );
        }
    }
}