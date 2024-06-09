using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace BloodBank.Infrastructure.EmailExtensions;

public class EmailHelper
{

    public string Provedor { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }

    public EmailHelper(string provedor, string username, string password)
    {
        Provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    public void SendEmail(List<string> emailsTo, string subject, string body, List<string> attachments)
    {
        var message = PrepareteMessage(emailsTo, subject, body, attachments);

        SendEmailBySmtp(message);
    }

    private MailMessage PrepareteMessage(List<string> emailsTo, string subject, string body, List<string> attachments)
    {
        var mail = new MailMessage();
        mail.From = new MailAddress(Username);

        foreach (var email in emailsTo)
        {
            if (ValidateEmail(email))
            {
                mail.To.Add(email);
            }
        }

        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        foreach (var file in attachments)
        {
            var data = new Attachment(file, MediaTypeNames.Application.Octet);
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = File.GetCreationTime(file);
            disposition.ModificationDate = File.GetLastWriteTime(file);
            disposition.ReadDate = File.GetLastAccessTime(file);

            mail.Attachments.Add(data);
        }

        return mail;
    }

    private bool ValidateEmail(string email)
    {
        Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
        if (expression.IsMatch(email))
            return true;

        return false;
    }

    //private void SendEmailBySmtp(MailMessage message)
    //{
    //    SmtpClient smtpClient = new SmtpClient("smtp.office365.com");
    //    smtpClient.Host = Provedor;
    //    smtpClient.Port = 587;
    //    smtpClient.EnableSsl = true;
    //    smtpClient.Timeout = 50000;
    //    smtpClient.UseDefaultCredentials = false;
    //    smtpClient.Credentials = new NetworkCredential(Username, Password);
    //    smtpClient.Send(message);
    //    smtpClient.Dispose();
    //}

    private void SendEmailBySmtp(MailMessage message)
    {
        try
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 50000;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Username, Password);

                // Log para verificar as credenciais e detalhes de conexão
                Console.WriteLine($"Enviando e-mail usando SMTP: {smtpClient.Host}:{smtpClient.Port}");
                Console.WriteLine($"SSL habilitado: {smtpClient.EnableSsl}");
                Console.WriteLine($"Usuário: {Username}");

                smtpClient.Send(message);
                Console.WriteLine("Email enviado com sucesso.");
            }
        }
        catch (SmtpException ex)
        {
            // Captura detalhes do erro SMTP
            Console.WriteLine($"Erro SMTP: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Detalhes internos do erro: {ex.InnerException.Message}");
            }
        }
        catch (Exception ex)
        {
            // Captura outros tipos de erro
            Console.WriteLine($"Erro: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Detalhes internos do erro: {ex.InnerException.Message}");
            }
        }
    }

}
