namespace DemoWebAPI.Services.MultiInjections;

public class NetherlandsService : ICountryService
{
    public string GetCapital()
        => "Netherlands > Amsterdam";
}
