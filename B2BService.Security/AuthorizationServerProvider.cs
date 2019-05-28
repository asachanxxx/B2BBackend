using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace B2BService.Security
{
    public class AuthorizationServerProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
             context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "Admin" || context.Password == "password1")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                identity.AddClaim(new Claim("username", "Admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Asanga C"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" || context.Password == "password1")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Asanga C"));
                context.Validated(identity);
            }
            else {
                context.SetError("Invalied Authontication . Please provide valied ones.");
                return;
            }
        }
    }
}
