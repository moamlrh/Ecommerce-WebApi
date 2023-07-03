using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;
public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    private readonly RepositoryContext _context;
    public CartRepository(RepositoryContext context)
        : base(context)
    {
        _context = context;
    }

    public void CreateCart(Cart cart) => Create(cart);
    public void DeleteCart(Cart cart) => Delete(cart);
    public void UpdateCart(Cart cart) => Update(cart);
    public void AddProductToCart(Cart cart) {
        
    }
    public async Task<Cart> GetCartAsync(Guid Id) =>
                await FindByCondition(x => x.Id == Id).Include(x => x.User).FirstOrDefaultAsync();
    public async Task<Cart> GetCartByUserIdAsync(Guid UserId) =>
                await FindByCondition(x => x.User.Id.ToString() == UserId.ToString()).FirstOrDefaultAsync();

}