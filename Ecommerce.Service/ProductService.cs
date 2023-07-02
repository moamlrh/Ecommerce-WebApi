using System.Security.Claims;
using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddAsync(ProductToAddDto productToAdd, string userId)
    {
        var product = _mapper.Map<Product>(productToAdd);
        product.UserId = userId;
        _repositoryManager.ProductsRepository.Add(product);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repositoryManager.ProductsRepository.GetAllAsync();
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productsDto;
    }

    public async Task<ProductDto> GetByIdAsync(Guid Id)
    {
        var _product = await _repositoryManager.ProductsRepository.GetByIdAsync(Id);
        var product = _mapper.Map<ProductDto>(_product);
        return product;
    }
}
