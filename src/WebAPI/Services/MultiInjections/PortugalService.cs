namespace DemoWebAPI.Services.MultiInjections;

public class PortugalService : ICountryService
{
    public string GetCapital()
        => "Portugal > Lisbon";
}
