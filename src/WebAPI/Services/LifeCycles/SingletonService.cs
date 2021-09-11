using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Services.LifeCycles
{
    public class SingletonService : ISingletonService
    {
        private static uint _instantiationCount;

        private readonly ILogger<SingletonService> _logger;

        public Guid ServiceId { get; private set; }

        public SingletonService(ILogger<SingletonService> logger)
        {
            this._logger = logger;

            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(SingletonService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }

        public void Dispose()
        {
            this._logger.LogInformation("Dispose");
            GC.SuppressFinalize(this);
        }
    }
}