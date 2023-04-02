namespace DemoWebAPI.Services.MultiInjections;

public interface IMultiInjection
{
    string GetServiceName();
}

public class MultiInjectionAService : IMultiInjection
{
    public string GetServiceName() => GetType().Name;
}

public class MultiInjectionBService : IMultiInjection
{
    public string GetServiceName() => GetType().Name;
}

public class MultiInjectionCService : IMultiInjection
{
    public string GetServiceName() => GetType().Name;
}
