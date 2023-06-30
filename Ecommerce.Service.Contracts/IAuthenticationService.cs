using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegisterDto user);
    Task<bool> ValidateUser(UserForAuthDto user);
}
