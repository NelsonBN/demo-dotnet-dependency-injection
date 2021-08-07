using System;

namespace WebAPI.Services.ServiceLocators
{
    public class LocatorService : ILocatorService
    {
        public int GetRadom(int min, int max)
        {
            Random random = new Random();

            return random.Next(min, max + 1);
        }
    }
}