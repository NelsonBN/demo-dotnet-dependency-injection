namespace DemoWebAPI.Services.DelegateFuncs;

public class IrelandService : ICountryService
{
    public string GetCapital()
        => "Ireland > Dublin";
}
