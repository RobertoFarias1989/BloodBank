namespace BloodBank.Infrastructure.EmailExtensions;

public class Email : IEmail
{
    public void SendEmail(string to, string subject, string body)
    {
        var outlook = new EmailHelper("smtp.gmail.com", "bloodbank248@gmail.com", "hdbq wrqx tklv xoge");
        outlook.SendEmail(new List<string> { to }, subject, body, new());
    }
}
