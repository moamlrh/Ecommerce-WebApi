using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    // [HttpPost("register", Name = "registerNewUser")]
    // public async Task<IActionResult> Register([FromBody] UserForRegisterDto user) {
    // }
}
