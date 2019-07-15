using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(B2BService.Service.Owin.OwinStartup))]

namespace B2BService.Service.Owin
{
    public class OwinStartup
    {
        public static string PublicClientId { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            PublicClientId = "self";
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var provider = new B2BService.Service.Providers.ApplicationOAuthProvider(PublicClientId);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/owin/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(100),
                //AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                Provider = provider

            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
