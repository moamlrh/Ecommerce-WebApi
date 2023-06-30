using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IProductService> productService;
    private readonly Lazy<IAuthenticationService> authenticationService;

    public ServiceManager(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        UserManager<User> userManager
    )
    {
        userService = new(() => new UserService(repositoryManager, mapper));
        authenticationService = new(
            () => new AuthenticationService(repositoryManager, mapper, userManager)
        );

        // productService = new(() => new ProductService(repositoryManager, mapper));
    }

    public IUserService UsersService => userService.Value;
    public IProductService ProductService => productService.Value;
    public IAuthenticationService AuthenticationService => authenticationService.Value;
}
