using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace B2BService.Service.Owin
{
//    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
//    {
//        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            context.Validated();
//        }

//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
//            //    if (context.UserName == "Admin" || context.Password == "password1")
//            //    {
//            //        identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
//            //        identity.AddClaim(new Claim("username", "Admin"));
//            //        identity.AddClaim(new Claim(ClaimTypes.Name, "Asanga C"));
//            //        context.Validated(identity);
//            //    }
//            //    else if (context.UserName == "user" || context.Password == "password1")
//            //    {
//            //        identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
//            //        identity.AddClaim(new Claim("username", "user"));
//            //        identity.AddClaim(new Claim(ClaimTypes.Name, "Asanga C"));
//            //        context.Validated(identity);
//            //    }
//            //    else {
//            //        context.SetError("Invalied Authontication . Please provide valied ones.");
//            //        return;
//            //    }

//            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

//            using (AuthRepository _repo = new AuthRepository())
//            {
//                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

//                if (user == null)
//                {
//                    context.SetError("invalid_grant", "The user name or password is incorrect.");
//                    return;
//                }
//            }

//            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
//            identity.AddClaim(new Claim("sub", context.UserName));
//            identity.AddClaim(new Claim("role", "user"));

//            context.Validated(identity);

//        }
//    }
}