namespace WebAPI.Services.Generics;

public class Car : Transport
{
    public Car()
        => TransportType = nameof(Car);
}
