using IdentityServer4.Models;

namespace WebAppDemo.Models
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
            new ApiScope("testapis", "Test API Scope")
        };
        public static IEnumerable<Client> Clients => new List<Client> {
            new Client {
                ClientId = "testclient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("testsecret".Sha256())
                    },
                    AllowedScopes = {
                        "testapis"
                    }
            }
        };
    }
}
