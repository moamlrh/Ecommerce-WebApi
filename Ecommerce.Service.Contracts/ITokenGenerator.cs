using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface ITokenGenerator
{
    public Task<TokenDto> CreateToken(User user);
    public Task<TokenDto> RefreshToken(TokenDto token);
}