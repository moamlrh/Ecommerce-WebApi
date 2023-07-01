namespace Ecommerce.Shared;

public record class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // was added just for testing
};
