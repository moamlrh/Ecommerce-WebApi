using Ecommerce.Entities.Models;

namespace Ecommerce.Contracts;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
}
