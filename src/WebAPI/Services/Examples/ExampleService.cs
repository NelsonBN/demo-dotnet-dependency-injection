using System;

namespace DemoWebAPI.Services.Examples;

public class ExampleService : IExampleService
{
    public string GetUsername()
        => "NelsonNobre";

    public Guid GetUserId()
        => Guid.NewGuid();
}
