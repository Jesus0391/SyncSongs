using IdentityModel.Client;
using Microsoft.Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(RoundMusic.Startup))]
namespace RoundMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = ConfigurationManager.AppSettings["Authority"],
                ClientId = ConfigurationManager.AppSettings["clientId"],
                ClientSecret = "secret",
                RedirectUri = "http://localhost:63318",
                Scope = "openid access_api",
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    SecurityTokenValidated = (n) =>
                    {
                        var claimIdentity = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType,
                            "GivenName",
                            "Role");
                        var client = new UserInfoClient(
                             $"{n.Options.Authority}/connect/userinfo"
                            );

                        var userInfo = client.GetAsync(n.ProtocolMessage.AccessToken).Result;
                        foreach (var claim in userInfo.Claims)
                        {
                            claimIdentity.AddClaim(new Claim(claim.Type, claim.Value));
                        }

                        //Toke information, access token, expires
                        claimIdentity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        claimIdentity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                        claimIdentity.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));

                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(
                            claimIdentity,
                            n.AuthenticationTicket.Properties
                            );
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}
