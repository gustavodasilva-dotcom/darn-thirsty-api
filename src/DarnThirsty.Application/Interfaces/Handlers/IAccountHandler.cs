using DarnThirsty.Application.Commands;
using DarnThirsty.Core.Entities;

namespace DarnThirsty.Application.Interfaces.Handlers;

public interface IAccountHandler
{
    Task ExecuteFirstAccessAsync(UserAccountRequest userAccountRequest);
    Task<string> ExecuteAuthAsync(UserAccountRequest userAccountRequest);
    Task<User> ExecuteUpdateAsync(string userId, UserRequest request);
}