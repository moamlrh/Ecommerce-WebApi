using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("/api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviecManager)
    {
        _serviceManager = serviecManager;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _serviceManager.UsersService.GetUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserById(Guid Id)
    {
        var user = await _serviceManager.UsersService.GetUserByIdAsync(Id);
        return Ok(user);
    }
}
