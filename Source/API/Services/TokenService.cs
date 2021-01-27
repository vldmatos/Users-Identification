using API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
	public static class TokenService
	{
		public static string GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Role, user.Role)
				}),

				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Settings.Key), SecurityAlgorithms.HmacSha256Signature),

				Expires = DateTime.UtcNow.AddHours(1)
			};

			var securityToken = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(securityToken);
		}
	}
}