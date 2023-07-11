using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IAuthenticationService
{
    Task<UserDto> RegisterUser(UserForRegisterDto user);
    Task<TokenDto> Login(UserForAuthDto user);
}
