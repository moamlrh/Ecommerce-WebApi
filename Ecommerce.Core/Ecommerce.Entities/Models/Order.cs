using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Entities.Enums;
using Ecommerce.Shared;

namespace Ecommerce.Entities.Models;

public class Order
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public string UserId { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem> Items { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
