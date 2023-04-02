using System;

namespace DemoWebAPI.Services.LifeCycles;

public interface ISingletonInstanceService
{
    Guid ServiceId { get; }
    string GetInstantiationDetails();
}

public class SingletonInstanceService : ISingletonInstanceService
{
    private static uint _instantiationCount;
    public Guid ServiceId { get; private set; }

    private readonly string _input1;
    private readonly DateTime _input2;

    public SingletonInstanceService(string input1, DateTime input2)
    {
        _input1 = input1;
        _input2 = input2;

        ServiceId = Guid.NewGuid();
        _instantiationCount++;
    }

    public string GetInstantiationDetails()
        => $"{nameof(SingletonInstanceService)} > InstantiationCount: {_instantiationCount}, ServiceId: {ServiceId} > Input1: {_input1}, Input2: {_input2}";
}
