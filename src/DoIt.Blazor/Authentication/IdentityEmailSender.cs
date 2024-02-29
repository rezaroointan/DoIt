using DoIt.Data.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;


namespace DoIt.Blazor.Authentication
{
    public class IdentityEmailSender : IEmailSender<AppUser>
    {
        // Variable for get app setting configs
        private readonly IConfiguration _configuration;

        public IdentityEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationLinkAsync(AppUser user, string email, string confirmationLink)
        {
            // Email content
            using MailMessage message = new();
            message.Subject = "Email Confirmation";
            message.From = new MailAddress("m.roointan.10@gmail.com");
            message.To.Add(email);
            message.Body = $"<a href='{confirmationLink}'>Click her</a> to confirm your account.";
            message.IsBodyHtml = true;

            // Send email using SMTP
            using (var client = new SmtpClient())
            {
                // Email sender credential
                NetworkCredential credential = new()
                {
                    UserName = "m.roointan.10@gmail.com",
                    Password = "ECDF87A6643FFF69ACA82B5976D91411284D"
                };

                // SMTP client
                client.Credentials = credential;
                client.Host = "smtp.elasticemail.com";
                client.Port = 2525;
                client.EnableSsl = true;

                // Send
                client.Send(message);
            }
        }

        public Task SendPasswordResetCodeAsync(AppUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }

        public Task SendPasswordResetLinkAsync(AppUser user, string email, string resetLink)
        {
            throw new NotImplementedException();
        }

    }
}
