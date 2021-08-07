namespace WebAPI.Services.MultiInjections
{
    public class NetherlandsService : ICountryService
    {
        public string GetCapital()
        {
            return "Netherlands > Amsterdam";
        }
    }
}