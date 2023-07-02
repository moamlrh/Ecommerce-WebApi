using System.Security.Claims;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters parameters);
    public Task<ProductDto> GetByIdAsync(Guid Id);
    public Task<ProductDto> AddAsync(ProductToAddDto product, string userId);
    public Task DeleteByIdAsync(Guid Id);
}
