using Ecommerce.Contracts;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager 
{
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IProductService> productService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        userService = new(() => new UserService(repositoryManager));
        productService = new(() => new ProductService(repositoryManager));
    }

    public IUserService UsersService => userService.Value;
    public IProductService ProductService => productService.Value;
}
