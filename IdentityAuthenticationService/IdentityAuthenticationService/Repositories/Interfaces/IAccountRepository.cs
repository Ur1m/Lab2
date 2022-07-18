using IdentityAuthenticationService.Models;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> SocialLogin(ApplicationUser user); 
    }
}
