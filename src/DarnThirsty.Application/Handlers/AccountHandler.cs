using DarnThirsty.Application.Commands;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Entities;
using DarnThirsty.Core.Exceptions;
using DarnThirsty.Core.Repositories;
using DarnThirsty.Tools.Extensions;

namespace DarnThirsty.Application.Handlers;

public class AccountHandler : IAccountHandler
{
    private readonly IUserRepository _userRepository;

    public AccountHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteFirstAccess(FirstAccessRequest firstAccessRequest)
    {
        if (await _userRepository.Exists(firstAccessRequest.Email))
            throw new DuplicatedEntityException(firstAccessRequest.Email);

        await _userRepository.Save(new User
        {
            email = firstAccessRequest.Email,
            password = firstAccessRequest.Password.EncryptString(),
            active = true
        });
    }
}