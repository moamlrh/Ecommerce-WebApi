using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Contracts;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync(ProductParameters parameters);
    public Task<Product> GetByIdAsync(Guid Id);
    public void Add(Product product);
    public void Delete(Product product);
}
