using System;

namespace WebAPI.Services.LifeCycles
{
    public class ScopedService : IScopedService
    {
        private static uint _instantiationCount;
        public Guid ServiceId { get; private set; }

        public ScopedService()
        {
            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(ScopedService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }
    }
}