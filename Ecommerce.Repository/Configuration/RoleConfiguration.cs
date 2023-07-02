using Ecommerce.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasData(
            new List<Role>
            {
                new Role { Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Name = "User", NormalizedName = "USER" },
            }
        );
    }
}
