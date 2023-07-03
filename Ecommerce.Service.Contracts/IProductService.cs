using System.Security.Claims;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IProductService
{
    public Task DeleteProductByIdAsync(Guid Id);
    public Task<ProductDto> GetProductByIdAsync(Guid Id);
    public Task<ProductDto> CreateProductAsync(ProductToAddDto product, string userId);
    public Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductParameters parameters);
}
