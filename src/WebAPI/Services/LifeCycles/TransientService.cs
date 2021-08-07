using System;

namespace WebAPI.Services.LifeCycles
{
    public class TransientService : ITransientService
    {
        private static uint _instantiationCount;
        public Guid ServiceId { get; private set; }

        public TransientService()
        {
            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(TransientService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }
    }
}