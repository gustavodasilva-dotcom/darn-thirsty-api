using DarnThirsty.Application.Commands;
using DarnThirsty.Application.Interfaces.Handlers;
using DarnThirsty.Core.Exceptions;
using DarnThirsty.Core.Repositories;

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
            throw new DuplicatedEntityException("");
    }
}