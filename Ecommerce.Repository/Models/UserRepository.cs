using Ecommerce.Contracts;
using Ecommerce.Entities.Models;

namespace Ecommerce.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext context)
        : base(context) { }

    public IEnumerable<User> GetUsers() => FindAll();
}
