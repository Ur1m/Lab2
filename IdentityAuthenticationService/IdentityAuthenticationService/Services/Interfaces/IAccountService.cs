using IdentityAuthenticationService.Models;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserViewModel> SocialLogin(SocialUserViewModel socialUsersViewModel);

        Task<string> GenerateJWToken(UserViewModel user);

    }
}
