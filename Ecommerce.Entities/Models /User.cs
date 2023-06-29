namespace Ecommerce.Entities.Models;

public class User
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IEnumerable<Product> Products { get; set; } = null!;
}
