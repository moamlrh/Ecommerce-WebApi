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
    private readonly IOptions<JWTOptions> _options;
    private User? _user;

    public AuthenticationService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        UserManager<User> userManager,
        IOptions<JWTOptions> options
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userManager = userManager;
        _options = options;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegisterDto user)
    {
        _user = _mapper.Map<User>(user);
        var result = await _userManager.CreateAsync(_user, user.Password);
        if (result.Succeeded)
        {
            if (_user.Email.EndsWith("@ecommerce.api")) // To check on condition you can change this!
                await _userManager.AddToRoleAsync(_user, "ADMIN");
            else
                await _userManager.AddToRoleAsync(_user, "USER");
        }
        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthDto user)
    {
        _user = await _userManager.FindByEmailAsync(user.Email);
        return _user != null && await _userManager.CheckPasswordAsync(_user, user.Password);
    }

    public async Task<string> CreateToke()
    {
        // create signing credentials
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));
        var secret = new SymmetricSecurityKey(key);
        var signingCred = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim("Id", _user.Id),
            new Claim("Username", _user.UserName),
            new Claim("Email", _user.Email)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(role.ToLower(), role));
        }
        // Generate Token
        return GetJwtSecurityToken(signingCred, claims);
    }

    private string GetJwtSecurityToken(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _options.Value;
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings.validIssuer,
            audience: jwtSettings.validAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.expires)),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
