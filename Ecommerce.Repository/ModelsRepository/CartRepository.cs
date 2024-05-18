using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;
public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    private readonly RepositoryContext _context;
    public CartRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cart?> GetCartByIdAsync(Guid Id) =>
                await FindByCondition(cart => cart.Id == Id)
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();
    public async Task<Cart?> GetCartByUserIdAsync(string UserId) =>
                await FindByCondition(cart => cart.UserId == UserId)
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();

    public async Task<IEnumerable<Cart>> GetAllCarts(string UserId) => await FindByCondition(cart => cart.UserId == UserId).ToListAsync();
}
