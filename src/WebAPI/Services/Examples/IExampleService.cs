using System;

namespace WebAPI.Services.Examples;

public interface IExampleService
{
    string GetUsername();
    Guid GetUserId();
}
