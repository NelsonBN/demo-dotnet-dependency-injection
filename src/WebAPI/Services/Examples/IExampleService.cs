using System;

namespace DemoWebAPI.Services.Examples;

public interface IExampleService
{
    string GetUsername();
    Guid GetUserId();
}
