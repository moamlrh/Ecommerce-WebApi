using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface ICartService
{
    public Task<Cart> CreateCartAsync(string UserId);
    public Task<CartDto> GetCartByIdAsync(Guid Id);
    public Task DeleteCartByIdAsync(Guid Id);
    public Task AddProductToCartAsync(string UserId, string ProductId);
    public Task RemoveProductFromCartAsync(Guid CartId, Guid ProductId);
    public Task ChangeProductQunatityAsync(Guid CartId, Guid ProductId, int Quantity);
}

