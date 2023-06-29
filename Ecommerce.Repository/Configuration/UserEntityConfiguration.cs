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
        // builder.HasData(
        //     new List<User>
        //     {
        //         new User
        //         {
        //             Id = 1,
        //             Age = 20,
        //             Email = "ahmed@gmail.com",
        //             IsAdmin = false,
        //             Name = "ahmed ali",
        //             Password = "123456"
        //         },
        //         new User
        //         {
        //             Id = 2,
        //             Age = 22,
        //             Email = "moaml@gmail.com",
        //             IsAdmin = true,
        //             Name = "moaml rh",
        //             Password = "asdfjl832"
        //         },
        //         new User
        //         {
        //             Id = 3,
        //             Age = 30,
        //             Email = "ali@gmail.com",
        //             IsAdmin = false,
        //             Name = "ali yousef",
        //             Password = "123456"
        //         },
        //     }
        // );
    }
}
