using System.Net;
using Service.Abstractions;
using System.Net.Mail;
using Entities.Models;
using Microsoft.Extensions.Options;

namespace Service.Services;

public class EmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _smtpServer = emailSettings.Value.SmtpServer;
        _smtpPort = emailSettings.Value.SmtpPort;
        _smtpUsername = emailSettings.Value.SmtpUsername;
        _smtpPassword = emailSettings.Value.SmtpPassword;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient(_smtpServer, _smtpPort)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_smtpUsername, _smtpPassword)
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpUsername),
            Subject = subject,
            Body = message,
            IsBodyHtml = true // Set to true to send HTML content
        };

        mailMessage.To.Add(email);

        await client.SendMailAsync(mailMessage);
    }

}