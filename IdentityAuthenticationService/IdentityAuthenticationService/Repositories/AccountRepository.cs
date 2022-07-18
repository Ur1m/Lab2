using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Repositories.Interfaces;
using IdentityAuthenticationService.Settings;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly MongoDbConfig mongoDbConfig; 




        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            MongoDbConfig mongoDbConfig)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mongoDbConfig = mongoDbConfig;
        }

        public async Task<ApplicationUser> SocialLogin(ApplicationUser user)
        {
            var applicationUser = await userManager.FindByNameAsync(user.UserName);

            if (applicationUser == null)
            {
                await userManager.CreateAsync(user);
                await signInManager.SignInAsync(user, false);
                return user;
            }
            else
            {
                await signInManager.SignInAsync(applicationUser, false);
                return applicationUser;
            }
        }
    }
}
