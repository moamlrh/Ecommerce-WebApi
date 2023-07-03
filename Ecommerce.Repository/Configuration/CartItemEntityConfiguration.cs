using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Repository.Configuration;

public class CartItemEntityConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");
        builder.HasOne(x => x.Cart).WithMany(p => p.CartItems).HasForeignKey(p => p.CartId);
        builder.HasOne(x => x.Product).WithMany(p => p.CartItems).HasForeignKey(p => p.ProductId);
    }
}
