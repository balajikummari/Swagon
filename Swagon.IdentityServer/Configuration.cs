using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Swagon.IdentityServer
{
    public static class Configuration
    {

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "rc.custom_Userclaims",
                    UserClaims =
                    { "rc.job", "rc.cat" }
                }
            };


        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> {
                new ApiResource("SwagonResourceApi",new string[] {"rc.job", "rc.cat","rc.api.job", ClaimTypes.Role }),
                new ApiResource("ApiClient"),
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client> {
                    new Client {
                        ClientId = "ResAPiclient_id",
                        ClientSecrets = { new Secret("ResApiclient_secret".ToSha256()) },
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = { "SwagonResourceApi" }
                    },

                    new Client {
                    ClientId = "MVCclient_id",
                    ClientSecrets = { new Secret("MVCclient_Secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "rc.custom_Userclaims","SwagonResourceApi"
                    },
                    RedirectUris = { "https://localhost:44302/signin-oidc" },
                    AllowOfflineAccess = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                    }
            };

    }
}
