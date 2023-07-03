using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Contracts;

public interface ICartRepository
{
    Task<Cart> GetCartAsync(Guid Id);
    Task<Cart> GetCartByUserIdAsync(Guid UserId);
    // void AddProductAsync(Product product);
    void CreateCart(Cart cart);
    void DeleteCart(Cart cart);
    void UpdateCart(Cart cart);

}
