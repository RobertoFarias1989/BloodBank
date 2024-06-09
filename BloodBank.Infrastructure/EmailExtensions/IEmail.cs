namespace BloodBank.Infrastructure.EmailExtensions;

public interface IEmail
{
    void SendEmail(string to, string subject, string body);
}
