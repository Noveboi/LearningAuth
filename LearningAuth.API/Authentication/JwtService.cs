using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LearningAuth.API.Authentication;

public class JwtService(string key, string issuer)
{
	private readonly string _key = key;
	private readonly string _issuer = issuer;

	public string CreateToken(ClaimsIdentity subject)
	{
		var sign = new SymmetricSecurityKey(
			SHA256.HashData(Encoding.UTF8.GetBytes(_key)));

		var handler = new JsonWebTokenHandler();
		return handler.CreateToken(new SecurityTokenDescriptor()
		{
			Expires = DateTime.UtcNow.AddMinutes(10),
			Issuer = _issuer,
			Subject = subject,
			SigningCredentials = new SigningCredentials(sign, SecurityAlgorithms.HmacSha256)
		});
	}
}
