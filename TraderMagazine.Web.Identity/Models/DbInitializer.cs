using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TraderMagazine.Web.Identity.Models.DbContext;

namespace TraderMagazine.Web.Identity.Models
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationContext context, UserManager<ApplicationUser> manager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _manager = manager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            if (_roleManager.FindByNameAsync(MetaData.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(MetaData.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(MetaData.Customer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111",
                FirstName = "Bob",
                LastName = "Admin"
            };

            var success = await _manager.CreateAsync(adminUser, "ASds1414*");

            if (success != null)
            {
                await _manager.AddToRoleAsync(adminUser, MetaData.Customer);
            }

            var admin = _manager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, MetaData.Customer),
            }).Result;

            ApplicationUser custUser = new ApplicationUser()
            {
                UserName = "custom@gmail.com",
                Email = "custom@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "222222222",
                FirstName = "Bob",
                LastName = "Custm"
            };

            var result = await _manager.CreateAsync(custUser, "ASds1414*");

            if (result != null)
            {
                await  _manager.AddToRoleAsync(custUser, MetaData.Customer);
            }

            var customer = _manager.AddClaimsAsync(custUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, custUser.FirstName + " " + custUser.LastName),
                new Claim(JwtClaimTypes.GivenName, custUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, custUser.LastName),
                new Claim(JwtClaimTypes.Role, MetaData.Customer),
            }).Result;
        }
    }
}
