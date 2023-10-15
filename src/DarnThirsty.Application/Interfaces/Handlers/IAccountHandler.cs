using DarnThirsty.Application.Commands.Account;

namespace DarnThirsty.Application.Interfaces.Handlers;

public interface IAccountHandler
{
    Task ExecuteFirstAccessAsync(AccountRequest userAccountRequest);
    Task<string> ExecuteAuthAsync(AccountRequest userAccountRequest);
    Task<UserResponse> ExecuteUpdateAsync(string userId, UserRequest request);
}