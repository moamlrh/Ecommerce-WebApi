namespace Ecommerce.Shared;

public class CartDto
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public string UserId { get; set; }
    public UserDto User { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}