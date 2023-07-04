namespace Ecommerce.Shared;

public class CartItemDto
{
    public ProductDto Product { get; set; }
    public int Quantity { get; set; }
}