using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetAllAsync();
}
