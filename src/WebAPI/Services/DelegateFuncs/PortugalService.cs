namespace DemoWebAPI.Services.DelegateFuncs;

public class PortugalService : ICountryService
{
    public string GetCapital()
        => "Portugal > Lisbon";
}
