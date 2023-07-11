namespace Ecommerce.Shared;

public class CartDto
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public UserDto User { get; set; }
    public IEnumerable<CartItemDto> CartItems { get; set; }
}