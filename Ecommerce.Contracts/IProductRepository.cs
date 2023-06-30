using Ecommerce.Entities.Models;

namespace Ecommerce.Contracts;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync();
}
