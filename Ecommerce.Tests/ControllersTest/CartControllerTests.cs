using System.Security.Claims;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Presentation.Controllers;
using Ecommerce.Repository;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Http;
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
}