using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Models;

public class User : IdentityUser
{
    public int Age { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
