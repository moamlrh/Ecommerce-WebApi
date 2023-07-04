using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly ITokenGenerator _tokenGenerator;
    private User? _user;

    public AuthenticationService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        UserManager<User> userManager,
        ITokenGenerator tokenGenerator
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<UserDto> RegisterUser(UserForRegisterDto user)
    {
        _user = _mapper.Map<User>(user);
        var result = await _userManager.CreateAsync(_user, user.Password);
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Error while creating user");

        var _userDto = _mapper.Map<UserDto>(_user);
        return _userDto;
    }

    public async Task<TokenDto> ValidateUser(UserForAuthDto user)
    {
        _user = await _userManager.FindByEmailAsync(user.Email);
        var succeeded = _user != null && await _userManager.CheckPasswordAsync(_user, user.Password);
        if (!succeeded)
            throw new UserLoginFaildException();
        return await _tokenGenerator.CreateToken(_user);
    }
}
