using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Shared;

namespace Ecommerce.Entities.Models;

public class Product
{
    public Guid Id { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(255)]
    public string Name { get; set; }
    [Column(TypeName = "decimal(15,2)")]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    [MinLength(5)]
    public string Description { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
