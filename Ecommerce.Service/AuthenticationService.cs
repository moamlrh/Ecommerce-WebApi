using AutoMapper;
using Ecommerce.Contracts;
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

    public AuthenticationService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        UserManager<User> userManager
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegisterDto user)
    {
        var _user = _mapper.Map<User>(user);
        var result = await _userManager.CreateAsync(_user, user.Password);
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(_user, "ADMIN");
        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthDto user)
    {
        var userFromDb = await _userManager.FindByEmailAsync(user.Email);
        var checkLogin =
            userFromDb != null && await _userManager.CheckPasswordAsync(userFromDb, user.Password);
        return checkLogin;
    }
}
