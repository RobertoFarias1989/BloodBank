using BloodBank.Application.Login.ViewModels;
using BloodBank.Core.Results;
using MediatR;

namespace BloodBank.Application.Login.Commands;

public class LoginCommand : IRequest<Result<LoginViewModel>>
{
    public LoginCommand(string? emailAddress, string? passwordValue)
    {
        EmailAddress = emailAddress;
        PasswordValue = passwordValue;
    }

    public string? EmailAddress { get; set; }
    public string? PasswordValue { get; set; }
}
