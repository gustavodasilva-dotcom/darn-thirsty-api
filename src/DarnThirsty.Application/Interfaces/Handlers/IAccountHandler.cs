using DarnThirsty.Application.Commands;

namespace DarnThirsty.Application.Interfaces.Handlers;

public interface IAccountHandler
{
    Task ExecuteFirstAccess(FirstAccessRequest firstAccessRequest);   
}