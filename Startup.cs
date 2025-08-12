using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.Jwt;  // if you use JWT
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System;  // <-- This is important for UseWebApi extension method

[assembly: OwinStartup(typeof(DotNetRESTfulCraze.Startup))]
namespace DotNetRESTfulCraze
{
  /*****************************************************************************************************
  Writer       : Kiran Kumar J
  Description  : Get to know about Creating Restful API with  model Product and loading data from
                 Controllers and access the APIS with JWT Authentication
  Created Date : 12 - August - 2025
  Created By   : Kiran Kumar
  Changed Date : 12 - August - 2025
  Changed By   : Kiran Kumar
  JIRA ID      : https://kiranjuvvanapudi.atlassian.net/browse/AMAECR-14
  *****************************************************************************************************/
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configure Web API routes (enable attribute routing)
            config.MapHttpAttributeRoutes();

            // Configure any middleware here, e.g., JWT Authentication
            ConfigureOAuth(app);

            // Connect Web API to OWIN pipeline
            app.UseWebApi(config);

        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = "http://yourdomain.com";
            var audience = "yourAudienceKey";
            var secret = TextEncodings.Base64Url.Decode("YourSecretBase64EncodedKey");


            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secret)  // Use byte[] directly here
                }
            });
        }
    }
}