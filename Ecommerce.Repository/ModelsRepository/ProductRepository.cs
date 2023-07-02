using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context)
        : base(context) { }

    public async Task<IEnumerable<Product>> GetAllAsync() => await FindAll().ToArrayAsync();

    public async Task<Product> GetByIdAsync(Guid Id) =>
        await FindByCondition(p => p.Id == Id).Include(e => e.User).SingleOrDefaultAsync();

    public void Add(Product product) => Create(product);

    public void Delete(Product product) => base.Delete(product);
}