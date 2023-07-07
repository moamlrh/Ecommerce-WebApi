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

    [Fact]
    public async void AddProductToCart_ValidCart_Test()
    {
        // arrange 
        var user = new User { Id = "1" };
        var cart = new Cart { Id = Guid.NewGuid(), UserId = user.Id, TotalPrice = 0 };
        var product = new Product { Id = Guid.NewGuid(), Price = 39m, Name = "Test", UserId = user.Id };
        _mockRepoManager.Setup(mang => mang.ProductsRepository.GetProductByIdAsync(product.Id)).Returns(Task.FromResult(product));

        _mockRepoManager.Setup(mang => mang.CartRepository.GetCartByUserIdAsync(user.Id)).Returns(Task.FromResult(cart));

        // act
        await _cartService.AddProductToCartAsync(user.Id, product.Id.ToString());

        // assert 
        Assert.Equal(cart.TotalPrice, product.Price);
        Assert.NotEmpty(cart.UserId);
        Assert.Equal(1, cart.CartItems.FirstOrDefault().Quantity);
        _mockRepoManager.Verify(service => service.SaveAsync(), Times.Once);
    }
}