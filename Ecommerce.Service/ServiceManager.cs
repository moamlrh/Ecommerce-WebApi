using AutoMapper;
using Ecommerce.Api.JwtConfig;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IProductService> productService;
    private readonly Lazy<IAuthenticationService> authService;

    public ServiceManager(
        IRepositoryManager repoManager,
        IMapper mapper,
        UserManager<User> userManager,
        IOptions<JWTOptions> options
    )
    {
        userService = new(() => new UserService(repoManager, mapper));
        productService = new(() => new ProductService(repoManager, mapper));
        authService = new(
            () => new AuthenticationService(repoManager, mapper, userManager, options)
        );
    }

    public IUserService UsersService => userService.Value;
    public IProductService ProductService => productService.Value;
    public IAuthenticationService AuthenticationService => authService.Value;
}
