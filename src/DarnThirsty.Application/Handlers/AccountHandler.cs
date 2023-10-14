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
using MongoDB.Bson;

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
            throw new ConflictException(userAccountRequest.Email);

        await _userRepository.Save(new User
        {
            email = userAccountRequest.Email.Trim(),
            password = userAccountRequest.Password.Trim().EncryptString(),
            active = true
        });
    }

    public async Task<string> ExecuteAuthAsync(UserAccountRequest request)
    {
        var user = await _userRepository.Get(u => u.email.Equals(request.Email.Trim())) ??
            throw new NotFoundException(request.Email);

        if (!user.password.DecryptString().Equals(request.Password.Trim()))
            throw new UnauthorizedException("The password informed is incorrect");

        return CreateToken(user);
    }

    public async Task<User> ExecuteUpdateAsync(string userId, UserRequest request)
    {
        var _userId = ObjectId.Parse(userId);

        var user = await _userRepository.Get(u => u.id == _userId) ??
            throw new NotFoundException(userId.ToString());

        if (await _userRepository.Exists(u => u.email == request.Email.Trim()
                                           && u.id != _userId))
            throw new ConflictException(request.Email.Trim());

        user.name = request.Name.Trim();
        user.email = request.Email.Trim();
        user.password = request.Password.Trim().EncryptString();
        user.active = request.Active;

        await _userRepository.Update(user);

        return await _userRepository.Get(u => u.id == _userId);
    }
}