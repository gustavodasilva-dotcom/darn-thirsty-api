using DarnThirsty.Application.Commands;

namespace DarnThirsty.Application.Interfaces.Handlers;

public interface IAccountHandler
{
    Task ExecuteFirstAccessAsync(UserAccountRequest userAccountRequest);
    Task<string> ExecuteAuthAsync(UserAccountRequest userAccountRequest);
}