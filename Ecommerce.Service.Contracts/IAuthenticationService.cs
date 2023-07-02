using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service.Contracts;

public interface IAuthenticationService
{
    Task<TokenDto> RegisterUser(UserForRegisterDto user);
    Task<TokenDto> ValidateUser(UserForAuthDto user);
    // Task<TokenDto> CreateToke();
}
