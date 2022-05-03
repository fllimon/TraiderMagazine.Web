using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace TraderMagazine.Web.Identity
{
    public static class MetaData
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("TraderMagazine", "Trader Server"),
                new ApiScope("read", "Read your data"),
                new ApiScope("write", "Write your data"),
                new ApiScope("delete", "Delete your data")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secretKey1111".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}

                },
                new Client
                {
                    ClientId = "TraderMagazine",
                    ClientSecrets = { new Secret("secretKey1111".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7222/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7222/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "TraderMagazine"
                    }

                },
            };
    }
}
