using System;

namespace WebAPI.Services.LifeCycles
{
    public class SingletonService : ISingletonService
    {
        private static uint _instantiationCount;
        public Guid ServiceId { get; private set; }

        public SingletonService()
        {
            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(SingletonService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId}";
        }
    }
}