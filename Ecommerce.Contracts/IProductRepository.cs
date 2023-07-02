using Ecommerce.Entities.Models;

namespace Ecommerce.Contracts;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product> GetByIdAsync(Guid Id);
    public void Add(Product product);
    public void Delete(Product product);
}
