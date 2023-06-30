using AutoMapper;
using Ecommerce.Contracts;
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

    public async Task<UserDto> GetUserByIdAsync(Guid Id)
    {
        var user = await _repositoryManager.UsersRepository.GetUserByIdAsync(Id);
        var userToReturn = _mapper.Map<UserDto>(user);
        return userToReturn;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _repositoryManager.UsersRepository.GetUsersAsync();
        var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(users);
        return usersToReturn;
    }
}
