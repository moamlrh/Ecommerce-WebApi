using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Repository.Configuration;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        // builder.HasData(
        //     new List<Product>
        //     {
        //         new Product
        //         {
        //             Id = 1,
        //             Name = "Iphone 10",
        //             Price = 3000m,
        //             UserId = 1
        //         },
        //         new Product
        //         {
        //             Id = 2,
        //             Name = "Iphone 2",
        //             Price = 100m,
        //             UserId = 1
        //         },
        //         new Product
        //         {
        //             Id = ,
        //             Name = "Iphone 13",
        //             Price = 3900m,
        //             UserId = 1
        //         },
        //     }
        // );
    }
}
