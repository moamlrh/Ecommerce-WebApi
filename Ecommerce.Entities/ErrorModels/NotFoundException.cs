namespace Ecommerce.Entities;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message)
        : base(message) { }
}
