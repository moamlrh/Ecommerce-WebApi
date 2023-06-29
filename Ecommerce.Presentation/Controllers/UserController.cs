using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviecManager)
    {
        _serviceManager = serviecManager;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        _serviceManager.UsersService.GetUsers();
        return Ok();
    }
}
