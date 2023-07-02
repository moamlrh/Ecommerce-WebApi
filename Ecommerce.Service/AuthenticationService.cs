using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Ecommerce.Api.JwtConfig;
using Ecommerce.Contracts;
using Ecommerce.Entities;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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

    public async Task<TokenDto> RegisterUser(UserForRegisterDto user)
    {
        _user = _mapper.Map<User>(user);
        var result = await _userManager.CreateAsync(_user, user.Password);
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Error while creating user");

        await _userManager.AddToRoleAsync(_user, "USER");
        return await _tokenGenerator.CreateToken(_user);
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
