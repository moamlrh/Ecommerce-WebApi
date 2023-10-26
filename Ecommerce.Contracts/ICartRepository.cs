using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Contracts;

public interface ICartRepository
{
    Task<Cart> GetCartByIdAsync(Guid Id);
    Task<Cart> GetCartByUserIdAsync(string UserId);
    Task<IEnumerable<Cart>> GetAllCarts(string UserId);
    Task CreateCart(Cart cart);
    void DeleteCart(Cart cart);
    Task UpdateCart(Cart cart);
    Task RemoveRange();
}
