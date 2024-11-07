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
            // Email API parameters
            Dictionary<string, string> parameters = new() {
                { "fromeName" , _configuration["EmailService:FromName"]! },
                { "from" , _configuration["EmailService:From"]! },
                { "apikey" , _configuration["EmailService:ApiKey"]! },
                { "to" , email },
                { "subject" , "Email Confirmation" },
                { "bodyText" , "" },
                { "bodyHtml" , $"<a href='{confirmationLink}'>Click her</a> to confirm your account." },
                { "isTransactional" , "true" },
            };

            // Send
            string response = await SedAsync(parameters);
        }

        private async Task<string> SedAsync(Dictionary<string, string> parameters)
        {
            using HttpClient httpClient = new();
            try
            {
                var content = new FormUrlEncodedContent(parameters);
                HttpResponseMessage response = await httpClient.PostAsync(_configuration["EmailService:ApiAddress"], content);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return $"Request error: {e.Message}\n{e.StackTrace}";
            }
            catch (Exception e)
            {
                return $"Exception caught: {e.Message}\n{e.StackTrace}";
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
