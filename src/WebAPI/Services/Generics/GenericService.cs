namespace DemoWebAPI.Services.Generics;

public interface IGenericService<TSource> where TSource : Transport
{
    string GetInstanceType(TSource source);
}


public class GenericService<TSource> : IGenericService<TSource> where TSource : Transport
{
    public string GetInstanceType(TSource source)
        => source.TransportType;
}
