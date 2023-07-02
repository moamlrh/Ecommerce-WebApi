using Ecommerce.Shared;

namespace Ecommerce.Entities.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
