﻿using System;

namespace DemoWebAPI.Services.ServiceLocators;

public interface ILocatorService
{
    int GetRadom(int min, int max);
}

public class LocatorService : ILocatorService
{
    public int GetRadom(int min, int max)
    {
        var random = new Random();

        return random.Next(min, max + 1);
    }
}
