namespace Ecommerce.Contracts;

public interface IRepositoryManager
{
    IUserRepository UsersRepository { get; }
    IProductRepository ProductsRepository { get; }
    Task SaveAsync();
}
