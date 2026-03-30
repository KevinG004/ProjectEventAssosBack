using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using ProjectEventAssos.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using ProjectEventAssos.Domain.Models;

namespace ProjectEventAssos.Core.Services.Auth
{


    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions <EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string password)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "Bienvenue sur Assoc'Event !";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                <h2>Bienvenue sur Assoc'Event, !</h2>
                <p>Votre inscription a bien été prise en compte.</p>
                <p>Votre mot de passe temporaire est {password}.</p>
                <p>Vous pouvez dès maintenant vous connecter et profiter de nos services.
                <br>
                   Lors de votre prochaine connection vous devrez changer votre mot de passe et vos données de profil</p>
                <br>
                <p>Cordialement,<br/>Assoc'Event</p>
            "
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.SenderEmail, _settings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
