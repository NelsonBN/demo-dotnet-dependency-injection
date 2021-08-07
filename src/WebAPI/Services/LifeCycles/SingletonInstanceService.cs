using System;

namespace WebAPI.Services.LifeCycles
{
    public class SingletonInstanceService : ISingletonInstanceService
    {
        private static uint _instantiationCount;
        public Guid ServiceId { get; private set; }

        private readonly string _input1;
        private readonly DateTime _input2;

        public SingletonInstanceService(string input1, DateTime input2)
        {
            this._input1 = input1;
            this._input2 = input2;

            this.ServiceId = Guid.NewGuid();
            _instantiationCount++;
        }

        public string GetInstantiationDetails()
        {
            return $"{nameof(SingletonInstanceService)} > InstantiationCount: {_instantiationCount}, ServiceId: {this.ServiceId} > Input1: {this._input1}, Input2: {this._input2}";
        }
    }
}