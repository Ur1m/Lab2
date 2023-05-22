using IdentityAuthenticationService.Models;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Services
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(MailRequest mailRequest);
        Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
