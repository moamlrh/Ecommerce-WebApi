using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;

namespace Ecommerce.Service;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _repositoryManager.UsersRepository.GetUsersAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid Id)
    {
        var user = await _repositoryManager.UsersRepository.GetUserByIdAsync(Id);
        if (user == null)
            throw new UserNotFoundException(Id.ToString());
        return _mapper.Map<UserDto>(user);
    }

    public async Task DeleteUserByIdAsync(Guid Id)
    {
        var user = await _repositoryManager.UsersRepository.GetUserByIdAsync(Id);
        if (user == null)
            throw new UserNotFoundException(Id.ToString());
        _repositoryManager.UsersRepository.DeleteUser(user);
        await _repositoryManager.SaveAsync();
    }

}
