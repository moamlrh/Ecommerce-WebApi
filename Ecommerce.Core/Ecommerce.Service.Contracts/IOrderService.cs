using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Service.Contracts;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(List<CartItem> Items);
}

