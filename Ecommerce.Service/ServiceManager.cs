using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IProductService> productService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        userService = new(() => new UserService(repositoryManager, mapper));
        // productService = new(() => new ProductService(repositoryManager, mapper));
    }

    public IUserService UsersService => userService.Value;
    public IProductService ProductService => productService.Value;
}
