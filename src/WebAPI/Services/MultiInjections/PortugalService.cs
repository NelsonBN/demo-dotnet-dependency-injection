namespace WebAPI.Services.MultiInjections
{
    public class PortugalService : ICountryService
    {
        public string GetCapital()
        {
            return "Portugal > Lisbon";
        }
    }
}