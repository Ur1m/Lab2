using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace IdentityAuthenticationService.Models
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string OAuthSubject { get; set; }

        public string OAuthIssuer { get; set; }
    }
}