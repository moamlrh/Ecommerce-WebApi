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
    private readonly Lazy<ICartService> cartService;

    public ServiceManager(
        IRepositoryManager repoManager,
        IMapper mapper,
        UserManager<User> userManager,
        IOptions<JWTOptions> options,
        ITokenGenerator tokenGenerator
    )
    {
        userService = new(() => new UserService(repoManager, mapper));
        cartService = new(() => new CartService(repoManager, mapper));
        productService = new(() => new ProductService(repoManager, mapper));
        authService = new(
            () => new AuthenticationService(repoManager, mapper, userManager, tokenGenerator)
        );
    }

    public ICartService CartService => cartService.Value;
    public IUserService UsersService => userService.Value;
    public IProductService ProductService => productService.Value;
    public IAuthenticationService AuthenticationService => authService.Value;

}
