namespace WebAPI.Services.Generics
{
    public class GenericService<TSource> : IGenericService<TSource> where TSource : Transport
    {
        public string GetInstanceType(TSource source)
        {
            return source.TransportType;
        }
    }
}