namespace Ecommerce.Shared;

public record class UserDto
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
};
