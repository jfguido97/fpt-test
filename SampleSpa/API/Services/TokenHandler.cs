using API.Model.Domain;
using API.Model.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> CreateTokenAsync(UserDto user)
        {
            //create claims, los jwt tiene datos esos datos se llaman claims, los claims son ejemplo name,surname,emial,roles, etc.
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Roles));

            //get key from appsettings
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //create credentials con las credencials y el algoritmo
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create the token
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            //con esto obtenemos el token en string, Task.FromResult es porque el metodo es de tipo async
            //task.FromResult retorna una tarea completada, lo cual es util para cuando tenemos un metod de tipo Task como retorno
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
