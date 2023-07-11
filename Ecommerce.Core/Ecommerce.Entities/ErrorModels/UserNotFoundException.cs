namespace Ecommerce.Entities;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string Id)
        : base($"User with {Id} was not found.") { }
}
