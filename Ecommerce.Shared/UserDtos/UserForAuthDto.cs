using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared;

public record class UserForAuthDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
