using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext context)
        : base(context) { }

    public async Task<IEnumerable<User>> GetUsersAsync() => await FindAll().ToArrayAsync();

    public async Task<User> GetUserByIdAsync(Guid Id) =>
        await FindByCondition(user => user.Id.Equals(Id)).FirstOrDefaultAsync();
}
