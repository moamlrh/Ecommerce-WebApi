using Ecommerce.Entities.Models;

namespace Ecommerce.Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(Guid Id);
    void DeleteUser(User user);
}
