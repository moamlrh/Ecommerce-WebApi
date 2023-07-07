using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using Moq;
using Ecommerce.Entities.Models;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Ecommerce.Contracts;
using AutoMapper;

public class CartServiceTests
{
    private readonly ICartService _cartService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IRepositoryManager> _mockRepoManager;
    public CartServiceTests()
    {
        _mockRepoManager = new Mock<IRepositoryManager>();
        _mockMapper = new Mock<IMapper>();
        _cartService = new CartService(_mockRepoManager.Object, _mockMapper.Object);

    }

    [Fact]
    public async void CreateCartReturnCartAsResult()
    {
        // arragne
        var TotalPrice = 10m;
        var cartId = Guid.NewGuid();
        var UserId = Guid.NewGuid();
        var cart = new Cart
        {
            Id = cartId,
            UserId = UserId.ToString(),
            TotalPrice = TotalPrice,
        };

        _mockRepoManager.Setup(x => x.CartRepository.CreateCart(cart)).Returns(Task.FromResult(cart));

        // act
        var result = await _cartService.CreateCartAsync(UserId.ToString());

        // assert
        Assert.Equal(UserId.ToString(), result.UserId);
        Assert.NotNull(result);
        Assert.IsType<Cart>(result);
    }
}