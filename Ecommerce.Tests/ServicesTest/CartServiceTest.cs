using Moq;
using Ecommerce.Entities.Models;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Ecommerce.Contracts;
using AutoMapper;
using Ecommerce.Shared;

namespace Ecommerce.Tests.ServicesTest;

public class CartServiceTests
{

    private readonly ICartService _cartService;
    private readonly User user;
    private readonly Cart cart;
    private readonly Product product;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IRepositoryManager> _mockRepoManager;
    public CartServiceTests()
    {
        _mockRepoManager = new Mock<IRepositoryManager>();
        _mockMapper = new Mock<IMapper>();
        _cartService = new CartService(_mockRepoManager.Object, _mockMapper.Object);

        user = new User { Id = "1" };
        product = new Product { Id = Guid.NewGuid(), Price = 39m, Name = "Test", UserId = user.Id };
        cart = new Cart { Id = Guid.NewGuid(), UserId = user.Id, TotalPrice = product.Price };
        cart.CartItems = new List<CartItem>
        {
            new CartItem { Id = cart.Id, Product= product, Cart = cart, ProductId = product.Id, Quantity = 1 }
        };
    }

    [Fact]
    public async void CreateCartReturnCartAsResult()
    {
        // arragne
        _mockRepoManager.Setup(x => x.CartRepository.CreateCart(cart)).Returns(Task.FromResult(cart));

        // act
        var result = await _cartService.CreateCartAsync(user.Id.ToString());

        // assert
        Assert.Equal(user.Id.ToString(), result.UserId);
        Assert.NotNull(result);
        Assert.IsType<Cart>(result);
    }

    [Fact]
    public async void AddProductToCart_ValidCart_Test()
    {
        // arrange 
        _mockRepoManager.Setup(mang => mang.ProductsRepository.GetProductByIdAsync(product.Id)).Returns(Task.FromResult(product));

        _mockRepoManager.Setup(mang => mang.CartRepository.GetCartByUserIdAsync(user.Id)).Returns(Task.FromResult(cart));

        // act
        await _cartService.AddProductToCartAsync(user.Id, product.Id.ToString());

        // assert 
        Assert.Equal(cart.TotalPrice, product.Price + product.Price);
        Assert.NotEmpty(cart.UserId);
        _mockRepoManager.Verify(service => service.SaveAsync(), Times.Once);
    }

    [Fact]
    public async void RemoveProductFromCart_()
    {
        // arrange
        _mockRepoManager.Setup(x => x.ProductsRepository.GetProductByIdAsync(product.Id)).Returns(Task.FromResult(product));
        _mockRepoManager.Setup(x => x.CartRepository.GetCartByIdAsync(cart.Id)).Returns(Task.FromResult(cart));

        // act 
        await _cartService.RemoveProductFromCartAsync(cart.Id, product.Id);

        // assert 
        Assert.Equal(cart.TotalPrice, 0);
        Assert.Empty(cart.CartItems);
        _mockRepoManager.Verify(x => x.SaveAsync(), Times.Once);
    }
    [Fact]
    public async void DeleteCartById_GetCartAndDeleted()
    {
        // arragne 
        _mockRepoManager.Setup(x => x.CartRepository.GetCartByIdAsync(cart.Id))
                            .Returns(Task.FromResult(cart));
        _mockRepoManager.Setup(x => x.CartRepository
                            .DeleteCart(cart))
                            .Callback<Cart>(c => c = null);

        // act 
        await _cartService.DeleteCartByIdAsync(cart.Id);

        // assert
        _mockRepoManager.Verify(x => x.CartRepository.DeleteCart(cart), Times.Once);
        _mockRepoManager.Verify(x => x.SaveAsync(), Times.Once);
    }
}