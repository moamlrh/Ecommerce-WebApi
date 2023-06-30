namespace Ecommerce.Service.Contracts;

public interface IServiceManager
{
    IUserService UsersService { get; }
    IProductService ProductService { get; }
    IAuthenticationService AuthenticationService { get; }
}
