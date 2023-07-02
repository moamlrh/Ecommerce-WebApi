using System.ComponentModel.DataAnnotations;
using Ecommerce.Entities;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthenticationController(IServiceManager serviceManager) =>
        _serviceManager = serviceManager;

    [HttpPost("register", Name = "registerNewUser")]
    [ServiceFilter(typeof(ValidationAttribute))]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto user)
    {
        var result = await _serviceManager.AuthenticationService.RegisterUser(user);
        return Ok(user);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationAttribute))]
    public async Task<IActionResult> Login([FromBody] UserForAuthDto user)
    {
        var result = await _serviceManager.AuthenticationService.ValidateUser(user);
        var Token = await _serviceManager.AuthenticationService.CreateToke();
        return Ok(new { Token });
    }
}
