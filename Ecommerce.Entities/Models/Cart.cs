using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Shared;

namespace Ecommerce.Entities.Models;

public class Cart
{
    public Guid Id { get; set; }
    public string UserId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
