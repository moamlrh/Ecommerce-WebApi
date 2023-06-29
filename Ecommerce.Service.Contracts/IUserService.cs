using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IUserService
{
    IEnumerable<UserDto> GetUsers();
}
