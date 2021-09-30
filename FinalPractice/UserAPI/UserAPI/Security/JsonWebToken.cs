using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Security
{
    public class JsonWebToken : IJsonWebToken
    {
        public string SignToken(User user, IConfiguration configuration)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Security:secret")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("Security:issuer"),
                    audience: configuration.GetValue<string>("Security:audience"),
                    claims: new List<Claim>()
                    {
                        new Claim("id", user.Id.ToString()),                        
                        new Claim("name", user.Name),                        
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
