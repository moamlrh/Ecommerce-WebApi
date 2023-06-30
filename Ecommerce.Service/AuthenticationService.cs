using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private User? _user;
    private IConfiguration _configuration;

    public AuthenticationService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration configuration
    )
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateToke()
    {
        var signingCred = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GetJwtSecurityToken(signingCred, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public static SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>() { new Claim(ClaimTypes.Name, _user.UserName) };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Name, role));

        return claims;
    }

    private JwtSecurityToken GetJwtSecurityToken(
        SigningCredentials signingCredentials,
        List<Claim> claims
    )
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["ValidIssuer"],
            audience: jwtSettings["ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
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
