using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
public class RequestServicesController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        var username = Service.GetUsername();
        var userId = Service.GetUserId();

        return Ok($"{nameof(username)}: {username} | {nameof(userId)}: {userId}");
    }
}
