using DarnThirsty.Application.Commands;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Exceptions;
using DarnThirsty.Core.Repositories;
using DarnThirsty.Tools.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DarnThirsty.Application.Handlers;

public class AccountHandler : IAccountHandler
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AccountHandler(IConfiguration configuration,
                          IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.name ?? string.Empty),
            new Claim(ClaimTypes.Email, user.email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("Jwt:SecretKey").Value!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task ExecuteFirstAccessAsync(UserAccountRequest userAccountRequest)
    {
        if (await _userRepository.Exists(userAccountRequest.Email))
            throw new DuplicatedEntityException(userAccountRequest.Email);

        await _userRepository.Save(new User
        {
            email = userAccountRequest.Email.Trim(),
            password = userAccountRequest.Password.Trim().EncryptString(),
            active = true
        });
    }

    public async Task<string> ExecuteAuthAsync(UserAccountRequest userAccountRequest)
    {
        var user = await _userRepository.Get(u => u.email.Equals(userAccountRequest.Email.Trim())) ??
            throw new NotFoundException(userAccountRequest.Email);

        if (!user.password.DecryptString().Equals(userAccountRequest.Password.Trim()))
            throw new UnauthorizedException("The password informed is incorrect");

        return CreateToken(user);
    }
}