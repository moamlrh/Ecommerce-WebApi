using System.Security.Claims;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface ICartService
{
    public Task<CartDto> GetCartByIdAsync(Guid Id);
    public Task<Cart> CreateCartAsync(string UserId);
    public Task<CartDto> GetCartByUserIdAsync(string UserId);
    public Task DeleteCartByIdAsync(Guid Id);
    public Task UpdateCartAsync(CartDto cart);
    public Task AddProductToCartAsync(string UserId, string ProductId);
    public Task<IEnumerable<CartDto>> GetAllCartsByUserIdAsync(string UserId);
    public Task RemoveProductFromCartAsync(Guid CartId, Guid ProductId);

}

