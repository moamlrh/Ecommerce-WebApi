using Ecommerce.Contracts;

namespace Ecommerce.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IUserRepository> userRepository;
    private readonly Lazy<IProductRepository> productRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        userRepository = new(() => new UserRepository(repositoryContext));
        productRepository = new(() => new ProductRepository(repositoryContext));
    }

    public IUserRepository UsersRepository => userRepository.Value;
    public IProductRepository ProductsRepository => productRepository.Value;

    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
}
