namespace BloodBank.Infrastructure.EmailExtensions;

public class Email : IEmail
{
    public void SendEmail(string to, string subject, string body)
    {
        var outlook = new EmailHelper("smtp.gmail.com", "INFORMEUMEMAILVALIDOAQUI248@gmail.com", "INFORME UMA SENHA VALIDA");
        outlook.SendEmail(new List<string> { to }, subject, body, new());
    }
}
