using IdentityAuthenticationService.Models;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserViewModel> SocialLogin(SocialUserViewModel socialUsersViewModel);

        Task<string> GenerateJWToken(UserViewModel user);

        Task<ApplicationUser> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);

        Task<ApplicationUser> FindUserOrAdd(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
    }
}
