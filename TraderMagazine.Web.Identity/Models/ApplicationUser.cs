using Microsoft.AspNetCore.Identity;

namespace TraderMagazine.Web.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set;}

        public string LastName { get; set;}
    }
}
