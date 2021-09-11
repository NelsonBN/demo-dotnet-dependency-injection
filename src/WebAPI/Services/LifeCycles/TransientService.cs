using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Services.LifeCycles
{
    public class TransientService : ITransientService
    {
        private static uint _instantiationCount;

        private readonly ILogger<TransientService> _logger;

        public Guid ServiceId { get; private set; }

        public TransientService(ILogger<TransientService> logger)
        {
            this._logger = logger;

            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(TransientService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }

        public void Dispose()
        {
            this._logger.LogInformation("Dispose");
            GC.SuppressFinalize(this);
        }
    }
}