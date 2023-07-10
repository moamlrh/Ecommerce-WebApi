using Ecommerce.Entities.Models;
using Ecommerce.Presentation.Controllers;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CartControllerTests
{
    private readonly CartController _controller;
    private readonly Mock<IServiceManager> _serviceManager;
    private Product product = new Product { Id = Guid.NewGuid(), Price = 10 };
    private Cart cart = new Cart { Id = Guid.NewGuid(), TotalPrice = 0 };
    public CartControllerTests()
    {
        _serviceManager = new Mock<IServiceManager>();
        _controller = new CartController(_serviceManager.Object);
    }

    [Fact]
    public async void GetCartById_ShouldReturnOkStatusWithCart()
    {
        // arrange
        var cart = new CartDto
        {
            Id = Guid.NewGuid(),
            TotalPrice = 0,
        };
        _serviceManager.Setup(mang => mang.CartService.GetCartByIdAsync(cart.Id)).Returns(Task.FromResult(cart));
        // act
        var result = await _controller.GetCartById(cart.Id) as OkObjectResult;

        // assert
        var response = Assert.IsType<CartDto>(result.Value);
        Assert.Equal(0, response.TotalPrice);
        Assert.NotNull(response);
    }

    [Fact]
    public async void DeleteProductFromCart_ReturnsString()
    {
        // arrange
        var cartId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        _serviceManager.Setup(mang => mang.CartService.RemoveProductFromCartAsync(cartId, productId)).Returns(Task.CompletedTask);

        // act
        var result = await _controller.DeleteProductFromCart(cartId, productId) as OkObjectResult;

        // assert
        var okResponse = Assert.IsType<OkObjectResult>(result as OkObjectResult);
        var responseString = okResponse.Value as string;
        Assert.Equal("Product has been deleted", responseString);
        Assert.NotNull(responseString);
    }
}