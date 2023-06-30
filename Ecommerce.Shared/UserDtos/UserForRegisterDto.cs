using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared;

public record class UserForRegisterDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [Range(13, int.MaxValue)]
    public int Age { get; set; }
};
