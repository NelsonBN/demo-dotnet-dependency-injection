namespace DemoWebAPI.Services.DelegateFuncs;

public class NetherlandsService : ICountryService
{
    public string GetCapital()
        => "Netherlands > Amsterdam";
}
