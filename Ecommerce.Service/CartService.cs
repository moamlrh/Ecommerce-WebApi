using System.Security.Claims;
using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;

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

    public async Task CreateCartAsync(string UserId)
    {
        var newCart = new Cart
        {
            UserId = UserId.ToString(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _repositoryManager.CartRepository.CreateCart(newCart);
        await _repositoryManager.SaveAsync();
    }

    public Task DeleteCartByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<CartDto> GetCartByIdAsync(Guid Id)
    {
        var cart = await _repositoryManager.CartRepository.GetCartAsync(Id);
        if (cart == null)
            throw new Exception("Cart not found!");

        var cartDto = _mapper.Map<CartDto>(cart);
        return cartDto;
    }

    public Task<CartDto> GetCartByUserIdAsync(string UserId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCartAsync(CartDto cart)
    {
        throw new NotImplementedException();
    }
    public async Task AddProductToCartAsync(string UserId, string ProductId)
    {
        var product = await _repositoryManager.ProductsRepository.GetByIdAsync(new Guid(ProductId));
        var cart = await _repositoryManager.CartRepository.GetCartByUserIdAsync(new Guid(UserId));
        if (cart == null)
        {
            await CreateCartAsync(UserId);
            await AddProductToCartAsync(UserId, ProductId);
            return;
        }
        cart.Products.Add(product);
        await _repositoryManager.SaveAsync();
    }
}
