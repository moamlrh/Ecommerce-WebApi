namespace Ecommerce.Contracts;

public interface IRepositoryManager
{
    IUserRepository UsersRepository { get; }
    ICartRepository CartRepository { get; }
    IOrderRepository OrderRepository { get; }
    IProductRepository ProductsRepository { get; }
    Task SaveAsync();
}
