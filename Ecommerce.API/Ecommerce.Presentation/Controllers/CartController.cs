using Microsoft.AspNetCore.Authorization;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/carts")]
[ApiController]
[Authorize]
public class CartController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public CartController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet("{CartId:guid}")]
    public async Task<IActionResult> GetCartById(Guid CartId)
    {
        var cart = await _serviceManager.CartService.GetCartByIdAsync(CartId);
        return Ok(cart);
    }

    [HttpPost("{ProductId:guid}")]
    public async Task<IActionResult> AddProductToCart(string ProductId)
    {
        var UserId = User.FindFirst("Id")?.Value;
        await _serviceManager.CartService.AddProductToCartAsync(UserId, ProductId);
        return Ok(new { UserId, ProductId });
    }

    [HttpDelete("{CartId:guid}/{ProductId:guid}", Name = "Delete Product")]
    public async Task<IActionResult> DeleteProductFromCart(Guid CartId, Guid ProductId)
    {
        await _serviceManager.CartService.RemoveProductFromCartAsync(CartId, ProductId);
        return Ok("Product has been deleted");
    }

    [HttpDelete("{CartId:guid}", Name = "Delete Cart")]
    public async Task<IActionResult> DeleteCart(Guid CartId)
    {
        await _serviceManager.CartService.DeleteCartByIdAsync(CartId);
        return Ok(new { message = "Cart Has been deleted" });
    }

    [HttpPut("{CartId:guid}/{ProductId:guid}", Name = "ChangeQuantity")]
    public async Task<IActionResult> ChangeProductQunatity(Guid CartId, Guid ProductId, [FromQuery] int Quantity)
    {
        await _serviceManager.CartService.ChangeProductQunatityAsync(CartId, ProductId, Quantity);
        return Ok(new { message = "Product Quantity has been changed" });
    }
}