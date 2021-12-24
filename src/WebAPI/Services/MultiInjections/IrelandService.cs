namespace WebAPI.Services.MultiInjections;

public class IrelandService : ICountryService
{
    public string GetCapital()
        => "Ireland > Dublin";
}
