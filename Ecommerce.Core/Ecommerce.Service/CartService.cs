using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;

namespace Ecommerce.Service;

public class CartService : ICartService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public CartService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<Cart> CreateCartAsync(string UserId)
    {
        var cart = new Cart
        {
            UserId = UserId.ToString(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        await _repositoryManager.CartRepository.CreateCart(cart);
        await _repositoryManager.SaveAsync();
        return cart;
    }
    public async Task DeleteCartByIdAsync(Guid Id)
    {
        var cart = await _repositoryManager.CartRepository.GetCartByIdAsync(Id);
        _repositoryManager.CartRepository.DeleteCart(cart);
        await _repositoryManager.SaveAsync();
    }
    public async Task<CartDto> GetCartByIdAsync(Guid Id)
    {
        var cart = await _repositoryManager.CartRepository.GetCartByIdAsync(Id);
        if (cart == null)
            throw new Exception("Cart was not found!");

        var cartItems = _mapper.Map<IEnumerable<CartItemDto>>(cart.CartItems);
        var cartDto = _mapper.Map<CartDto>(cart);
        cartDto.CartItems = cartItems;
        return cartDto;
    }
    public async Task RemoveProductFromCartAsync(Guid CartId, Guid ProductId)
    {
        var cart = await _repositoryManager.CartRepository.GetCartByIdAsync(CartId);
        if (cart == null)
            throw new Exception("Could not find product/cart");

        var cartItem = cart.CartItems.Where(p => p.Product.Id == ProductId).FirstOrDefault(); // Get product
        if (cartItem == null)
            throw new ProductNotFoundException(ProductId);

        var cartItems = cart.CartItems.Where(p => p.Product.Id != ProductId).ToList(); // Get cart items with the product
        cart.CartItems = cartItems;
        cart.TotalPrice -= cartItem.Product.Price;

        await _repositoryManager.SaveAsync();
    }
    public async Task AddProductToCartAsync(string UserId, string ProductId)
    {
        var product = await _repositoryManager.ProductsRepository.GetProductByIdAsync(new Guid(ProductId));
        if (product == null)
            throw new ProductNotFoundException(new Guid(ProductId));

        var cart = await _repositoryManager.CartRepository.GetCartByUserIdAsync(UserId);
        if (cart == null)
            cart = await CreateCartAsync(UserId);

        // if the product is already in cart or not
        var cartItem = cart.CartItems.Where(p => p.ProductId == Guid.Parse(ProductId)).FirstOrDefault();
        if (cartItem == null)
        {
            cart.CartItems.Add(new()
            {
                Quantity = 1,
                CartId = cart.Id,
                ProductId = product.Id,
            });
        }
        else
        {
            cartItem.Quantity++;
        }
        cart.TotalPrice += product.Price;
        await _repositoryManager.SaveAsync();
    }

    public async Task ChangeProductQunatityAsync(Guid CartId, Guid ProductId, int Quantity)
    {
        if (Quantity <= 0)
            throw new Exception("Quantity must be greater than 0");

        var cart = await _repositoryManager.CartRepository.GetCartByIdAsync(CartId);
        if (cart == null)
            throw new Exception("Cart was not found.");

        var cartItem = cart.CartItems.Where(p => p.ProductId == ProductId).FirstOrDefault();
        if (cartItem == null)
            throw new ProductNotFoundException(ProductId);


        if (cartItem.Quantity > Quantity)
            cart.TotalPrice += (Quantity - cartItem.Quantity) * cartItem.Product.Price;
        else
            cart.TotalPrice -= (cartItem.Product.Price * Quantity);

        cartItem.Quantity = Quantity;
        await _repositoryManager.SaveAsync();
    }
}
