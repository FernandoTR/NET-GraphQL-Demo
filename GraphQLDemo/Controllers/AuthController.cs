using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Usuario y contraseña de ejemplo (Estas credenciales no deben de ir aquí)
        private const string ValidUsername = "usuario_demo";
        private const string ValidPassword = "12345";

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] UserLogin userLogin)
        {
            // Validación del usuario y contraseña
            if (userLogin.Username != ValidUsername || userLogin.Password != ValidPassword)
            {
                return Unauthorized("Usuario o contraseña incorrectos");
            }

            // Creación de los claims del token
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub, userLogin.Username),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Configuración de la clave y las credenciales
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("n4dBgAga0Il3W66tiu41Gv0wZrkgJg+DNBMoQIOFyno="));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generación del token
            var token = new JwtSecurityToken(
                issuer: "tu_issuer",
                audience: "tu_audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            // Retorno del token en formato de cadena
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

