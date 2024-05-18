using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Contracts;

public interface ICartRepository : IRepositoryBase<Cart>
{
    Task<Cart?> GetCartByIdAsync(Guid Id);
    Task<Cart?> GetCartByUserIdAsync(string UserId);
    Task<IEnumerable<Cart>> GetAllCarts(string UserId);
}
