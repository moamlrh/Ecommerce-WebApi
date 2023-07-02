using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared;

public record class ProductToAddDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    [MinLength(5)]
    public string Description { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
}
