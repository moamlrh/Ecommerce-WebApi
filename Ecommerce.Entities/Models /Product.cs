namespace Ecommerce.Entities.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int UserId { get; set; }
    // public User User { get; set; } = null!;
}
