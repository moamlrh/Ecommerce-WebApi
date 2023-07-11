using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared;

public record class UserForRegisterDto
{
    public string Email { get; set; }

    public string Password { get; set; }
    public string Username { get; set; }
};
