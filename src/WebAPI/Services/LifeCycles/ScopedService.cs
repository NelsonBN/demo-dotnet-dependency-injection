using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Services.LifeCycles
{
    public class ScopedService : IScopedService
    {
        private static uint _instantiationCount;

        private readonly ILogger<ScopedService> _logger;

        public Guid ServiceId { get; private set; }

        public ScopedService(ILogger<ScopedService> logger)
        {
            this._logger = logger;

            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(ScopedService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }

        public void Dispose()
        {
            this._logger.LogInformation("Dispose");
            GC.SuppressFinalize(this);
        }
    }
}