namespace Ecommerce.Entities.Models;

public class User
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
