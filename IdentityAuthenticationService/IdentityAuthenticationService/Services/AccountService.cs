using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdentityAuthenticationService.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMailService mailService;

        public AccountService(UserManager<ApplicationUser> userManager, IMailService mailService)
        {
            this.userManager = userManager;
            this.mailService = mailService;
        }

        public async Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel forgetPasswordViewModel)
        {
            var user = await userManager.FindByEmailAsync(forgetPasswordViewModel.Email);

            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                token = HttpUtility.UrlEncode(token);

                await SendResetPasswordEmail(forgetPasswordViewModel.Email, token);
            }

            return user;
        }

        public async Task<string> GenerateJWToken(ApplicationUser user)
        {
            var Claims = new List<Claim>();
            string roles = null;
            try
            {
                var getRole = await userManager.GetRolesAsync(user);

                foreach (var role in getRole)
                {
                    roles = role;
                }
            }
            catch { }

            var tokenHandler = new JwtSecurityTokenHandler();

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();

            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);

            var tokenString = "";

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {

                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
                        new Claim(ClaimTypes.Role, roles == null ? "" : roles)
                    }),

                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)

                };


                var token = tokenHandler.CreateToken(tokenDescriptor);

                tokenString = tokenHandler.WriteToken(token);
            }

            catch
            {
                throw new Exception("You need to login first!");
            }

            return tokenString;
        }

        public async Task<ApplicationUser> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user != null)
            {
                resetPasswordViewModel.Token = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return user;
                }
                foreach (var error in result.Errors)
                {
                    return null;
                }
            }

            return user;
        }

        private async Task<bool> SendResetPasswordEmail(string email, string token)
        {

            var emailTemplateFile = Directory.GetCurrentDirectory() + "\\Templates\\SendResetPasswordEmailTemplate.html";
            StreamReader str = new StreamReader(emailTemplateFile);
            string emailTemplate = str.ReadToEnd();
            var builder = new BodyBuilder();
            builder.HtmlBody = emailTemplate;

            string clientBaseUrl = "http://localhost:3000";

            if (emailTemplate != null)
            {
                string resetLink = $"{clientBaseUrl}/reset-password?&token=" + token;

                builder.HtmlBody = emailTemplate.Replace("{{LINK}}", resetLink);
                var mailRequest = new MailRequest()
                {
                    Subject = "Forgot Password Reset Link",
                    ToEmail = email,
                    Body = builder.HtmlBody
                };

                var result = await mailService.SendEmailAsync(mailRequest);

                return result;
            }

            return false;
        }
    }
}
