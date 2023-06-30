using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Repository.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.HasData(
            new List<User>
            {
                new User
                {
                    Age = 21,
                    Email = "moaml@gmail.com",
                    Id = Guid.NewGuid(),
                    IsAdmin = true,
                    Name = "Moaml Rh",
                    Password = "mo12345"
                },
                new User
                {
                    Age = 22,
                    Email = "hood@gmail.com",
                    Id = Guid.NewGuid(),
                    IsAdmin = false,
                    Name = "HoodAhmed",
                    Password = "mo12343"
                },
            }
        );
    }
}
