using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid Id);
}
