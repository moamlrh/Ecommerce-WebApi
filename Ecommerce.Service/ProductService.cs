using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;

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

    public async Task<ProductDto> CreateProductAsync(ProductToAddDto productToAdd, string userId)
    {
        var product = _mapper.Map<Product>(productToAdd);
        product.UserId = userId;
        _repositoryManager.ProductsRepository.AddProduct(product);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteProductByIdAsync(Guid Id)
    {
        var productToDelete = await _repositoryManager.ProductsRepository.GetProductByIdAsync(Id);
        if (productToDelete == null)
            throw new ProductNotFoundException(Id);

        _repositoryManager.ProductsRepository.DeleteProduct(productToDelete);
        await _repositoryManager.SaveAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters parameters)
    {
        var products = await _repositoryManager.ProductsRepository.GetAllProductsAsync(parameters);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productsDto;
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid Id)
    {
        var _product = await _repositoryManager.ProductsRepository.GetProductByIdAsync(Id);
        var product = _mapper.Map<ProductDto>(_product);
        if (product is null)
            throw new ProductNotFoundException(Id);
        return product;
    }
}
