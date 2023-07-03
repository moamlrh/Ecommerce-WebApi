using Ecommerce.Presentation.Actions;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/cart")]
[ApiController]
[Authorize]
public class CartController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public CartController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCartById(Guid Id)
    {
        var cart = await _serviceManager.CartService.GetCartByIdAsync(Id);
        return Ok(cart);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCart()
    {
        var userId = User.FindFirst("Id")?.Value;
        await _serviceManager.CartService.CreateCartAsync(userId);
        return Ok("Cart created successfully");
    }

    [HttpPost("{ProductId}")]
    public async Task<IActionResult> AddProductToCart(string ProductId)
    {
        var userId = User.FindFirst("Id")?.Value;
        await _serviceManager.CartService.AddProductToCartAsync(userId, ProductId);
        return Ok("Product added to cart successfully");
    }
}