using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace DotNetRESTfulCraze.Controllers
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
    // Controllers/TokenController.cs
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("generate")]
        public IHttpActionResult GenerateToken(LoginRequest login)
        {
            if (login.Username == "admin" && login.Password == "1234")
            {
                var token = CreateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string CreateJwtToken(string username)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String("YourSecretBase64EncodedKey");
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "http://yourdomain.com",
                Audience = "yourAudienceKey",
                SigningCredentials = credentials
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
