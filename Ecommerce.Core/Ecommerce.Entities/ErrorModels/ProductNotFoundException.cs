namespace Ecommerce.Entities;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id)
        : base($"Product with {Id} was not found in our Database") { }
}
