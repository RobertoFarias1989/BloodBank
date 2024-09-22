namespace BloodBank.Application.Login.ViewModels;

public class LoginViewModel
{
    public LoginViewModel(string emailAddress, string token)
    {
        EmailAddress = emailAddress;
        Token = token;
    }

    public string EmailAddress { get; private set; }
    public string Token { get; private set; }
}
