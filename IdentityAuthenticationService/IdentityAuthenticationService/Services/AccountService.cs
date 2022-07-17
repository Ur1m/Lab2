using AutoMapper;
using IdentityAuthenticationService.Models;
using IdentityAuthenticationService.Repositories.Interfaces;
using IdentityAuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAuthenticationService.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IMapper mapper;
        private IAccountRepository accountRepository;


        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IAccountRepository accountRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        public async Task<string> GenerateJWToken(UserViewModel user)
        {
            var appUser = mapper.Map<ApplicationUser>(user);
            var Claims = new List<Claim>();
            string roles = null;
            try
            {
                var getRole = await userManager.GetRolesAsync(appUser);

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

        public async Task<UserViewModel> SocialLogin(SocialUserViewModel socialUserViewModel)
        { 
            string[] fullName = socialUserViewModel.Name.Split(' ');
            string firstName = "";
            string lastName = "";

            for (int i = 0; i < fullName.Length - 1; i++)
            {
                firstName += fullName[i] + " ";
            }
            firstName = firstName.TrimEnd();
            lastName = fullName[fullName.Length - 1];
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = socialUserViewModel.Email,
                FirstName = firstName,
                Email = socialUserViewModel.Email,
                LastName = lastName,
                CreatedAt = DateTime.Now,
                EmailConfirmed = true
            };


            var result = await accountRepository.SocialLogin(applicationUser);

            var userViewModel = mapper.Map<UserViewModel>(result);

            return userViewModel;
        }

        private async Task<ApplicationUser> FindUserOrAdd(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            var user = userManager.FindByEmailAsync(payload.Email).Result;
            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = payload.Name,
                    UserName = payload.Email,
                    OAuthSubject = payload.Subject,
                    OAuthIssuer = payload.Issuer
                };

                var result = await userManager.CreateAsync(newUser);
                if (result.Succeeded)
                {
                    return newUser;
                }
            }
            return user;
        }

        public async Task<ApplicationUser> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            await Task.Delay(1);
            return await FindUserOrAdd(payload);
        }
    }
}
