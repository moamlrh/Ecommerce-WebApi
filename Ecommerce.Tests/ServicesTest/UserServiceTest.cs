using AutoMapper;
using Moq;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;
using Ecommerce.Service.Contracts;
using Ecommerce.Service;

namespace Ecommerce.Tests.ServicesTest;

public class UserServiceTest
{
    private readonly IUserService _userService;
    private readonly Mock<IRepositoryManager> _repositoryManager;
    private readonly Mock<IMapper> _mapper;
    private IEnumerable<User> users;
    private List<UserDto> usersDto;

    public UserServiceTest()
    {
        _repositoryManager = new Mock<IRepositoryManager>();
        _mapper = new Mock<IMapper>();

        _userService = new UserService(_repositoryManager.Object, _mapper.Object);

        users = new List<User>()
        {
            new User { Id="1", Email="Ali@gmail.com" },
            new User { Id="2", Email="A21l@gmail.com" },
            new User { Id="3", Email="A32@gmail.com" },
        };
        usersDto = new List<UserDto>()
        {
            new(){ Id="1", Email="Ali@gmail.com" },
            new(){ Id="2", Email="A21l@gmail.com" },
            new(){ Id="3", Email="A32@gmail.com" },
        };
    }

    [Fact]
    public async void GetUsers_ReturnListOfUsers()
    {
        // Arrange 
        _repositoryManager.Setup(mang => mang.UsersRepository.GetUsersAsync()).Returns(Task.FromResult(users));
        _mapper.Setup(x => x.Map<IEnumerable<UserDto>>(users)).Returns(usersDto);


        // Act 
        var result = await _userService.GetUsersAsync();

        // Assert 
        Assert.NotNull(result);
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
    }
    [Fact]
    public void RemoveUserById_shouldReturnTrue()
    {
        // arrange 
        

        // act 

        // assert 
    }
}