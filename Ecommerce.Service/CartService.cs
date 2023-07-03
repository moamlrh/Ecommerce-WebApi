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

        var prodcuts = cart.CartItems.Select(c => c.Product);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(prodcuts);
        var cartDto = _mapper.Map<CartDto>(cart);
        cartDto.Products = productsDto;
        return cartDto;
    }

    public Task<CartDto> GetCartByUserIdAsync(string UserId)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<CartDto>> GetAllCartsByUserIdAsync(string UserId)
    {
        var carts = await _repositoryManager.CartRepository.GetAllCarts(UserId);
        var cartsDto = _mapper.Map<IEnumerable<CartDto>>(carts);
        return cartsDto;
    }

    public async Task RemoveProductFromCartAsync(Guid CartId, Guid ProductId)
    {
        var cart = await _repositoryManager.CartRepository.GetCartByIdAsync(CartId);
        var product = await _repositoryManager.ProductsRepository.GetByIdAsync(ProductId);

        if (cart == null || product == null)
            throw new Exception("Could not find product/cart");

        var cartItems = cart.CartItems.Where(p => p.Id != product.Id).ToList();
        cart.CartItems = cartItems;

        await _repositoryManager.CartRepository.UpdateCart(cart);
        await _repositoryManager.SaveAsync();
    }
    public Task UpdateCartAsync(CartDto cart)
    {
        throw new NotImplementedException();
    }
    public async Task AddProductToCartAsync(string UserId, string ProductId)
    {
        // if the products exist
        var product = await _repositoryManager.ProductsRepository.GetByIdAsync(new Guid(ProductId));
        if (product == null)
            throw new ProductNotFoundException(new Guid(ProductId));

        // get cart by user id
        var cart = await _repositoryManager.CartRepository.GetCartByUserIdAsync(UserId);
        // if cart doesn't exist
        if (cart == null)
            cart = await CreateCartAsync(UserId);


        var ProductFromCart = cart.CartItems.FirstOrDefault(p => p.ProductId == Guid.Parse(ProductId));
        // if product doesn't exists in the cart
        if (ProductFromCart == null)
        {
            // add product to the cart and increase the quantity 
            var prodcutToAdd = new CartItem()
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = 1
            };
            cart.CartItems.Add(prodcutToAdd);
        }
        // if product already exists in the cart
        else
        {
            // increase the quantity
            ProductFromCart.Quantity++;
        }

        cart.TotalPrice += product.Price;
        await _repositoryManager.CartRepository.UpdateCart(cart);
        await _repositoryManager.SaveAsync();
    }

}
