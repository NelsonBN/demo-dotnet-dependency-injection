namespace WebAPI.Services.Generics
{
    public class Car : Transport
    {
        public Car()
        {
            this.TransportType = nameof(Car);
        }
    }
}