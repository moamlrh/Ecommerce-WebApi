using System.Security.Claims;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface ICartService
{
    public Task<CartDto> GetCartByIdAsync(Guid Id);
    public Task<CartDto> GetCartByUserIdAsync(string UserId);
    public Task DeleteCartByIdAsync(Guid Id);
    public Task CreateCartAsync(string UserId);
    public Task UpdateCartAsync(CartDto cart);
    public Task AddProductToCartAsync(string UserId, string ProductId);
}
