using Ecommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            typeof(Configuration.UserEntityConfiguration).Assembly
        );
    }
}
