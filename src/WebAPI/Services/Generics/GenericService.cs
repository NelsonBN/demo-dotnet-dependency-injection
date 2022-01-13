namespace DemoWebAPI.Services.Generics;

public class GenericService<TSource> : IGenericService<TSource> where TSource : Transport
{
    public string GetInstanceType(TSource source)
        => source.TransportType;
}
