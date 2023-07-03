using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entities.Models;

public class Cart
{
    public Guid Id { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
