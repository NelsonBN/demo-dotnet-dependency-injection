using System;

namespace WebAPI.Services.ServiceLocators;

public class LocatorService : ILocatorService
{
    public int GetRadom(int min, int max)
    {
        var random = new Random();

        return random.Next(min, max + 1);
    }
}
