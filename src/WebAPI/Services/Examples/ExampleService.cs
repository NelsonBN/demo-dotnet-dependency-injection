using System;

namespace DemoWebAPI.Services.Examples;

public interface IExampleService
{
    string GetUsername();
    Guid GetUserId();
}

public class ExampleService : IExampleService
{
    public string GetUsername()
        => "NelsonNobre";

    public Guid GetUserId()
        => Guid.NewGuid();
}
