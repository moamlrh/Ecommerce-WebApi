using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Contracts;

public interface IProductRepository
{
    public void AddProduct(Product product);
    public void DeleteProduct(Product product);
    public Task<Product> GetProductByIdAsync(Guid Id);
    public Task<IEnumerable<Product>> GetAllProductsAsync(ProductParameters parameters);
}
