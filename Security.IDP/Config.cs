using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("companyApi", "CompanyEmployee API")
               
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
               {
                    ClientId = "company-employee",
                    ClientSecrets = new [] { new Secret("codemazesecret".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =  { IdentityServerConstants.StandardScopes.OpenId,"companyApi" }
                },
                 new Client
                 {
                     ClientName = "Image Gallery",
                     ClientId = "imagegalleryclient",
                     AllowedGrantTypes = GrantTypes.Code,
                     RequirePkce = true,
                     RedirectUris = new List<string>()
                     {
                         "https://localhost:44391/signin-oidc"
                     },
                     PostLogoutRedirectUris = new List<string>()
                     {
                         "https://localhost:44391/signout-callback-oidc"
                     },
                     AllowedScopes =
                     {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile
                     },
                     ClientSecrets = {new Secret("secret".Sha256())}
                 }
            };
    }
}
