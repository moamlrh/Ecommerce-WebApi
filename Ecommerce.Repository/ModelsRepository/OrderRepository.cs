using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;
public class OrderRepository : RepositoryBase<Cart>, IOrderRepository
{
    public OrderRepository(RepositoryContext context)
        : base(context)
    {
    }
}