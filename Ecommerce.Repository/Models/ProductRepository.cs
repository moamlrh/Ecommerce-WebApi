using Ecommerce.Contracts;
using Ecommerce.Entities.Models;

namespace Ecommerce.Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context)
        : base(context) { }
}
