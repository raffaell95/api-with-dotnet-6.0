using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
    public Token CreateToken(CustomIdentityUser usuario, string? role)
    {
        Claim[] direitosUsuario = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
        };

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("dsdgdhyh6u5667u6uyturiikukuyyrhfhfg0")
        );
        
        var credentiais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
          claims: direitosUsuario,
          signingCredentials: credentiais,
          expires: DateTime.UtcNow.AddHours(1)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new Token(tokenString);
    }
}