using IdentityAuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> GenerateJWToken(ApplicationUser user);

        Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel forgetPasswordViewModel);
    }
}
