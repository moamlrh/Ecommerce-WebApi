namespace Ecommerce.Service.Contracts;

public interface IServiceManager
{
    ICartService CartService { get; }
    IUserService UsersService { get; }
    IProductService ProductService { get; }
    IAuthenticationService AuthenticationService { get; }
}
