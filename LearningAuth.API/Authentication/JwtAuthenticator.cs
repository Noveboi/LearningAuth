using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;

namespace LearningAuth.API.Authentication;
public class JwtAuthenticator(JwtService jwtService)
{
	private readonly JwtService _jwtService = jwtService;

	public string CreateUserToken(IUser user)
	{
		// Construct the Claims Principal and create the cookie.
		var claims = new List<Claim>()
		{
			new(ClaimTypes.Name, user.Username),
			new(ClaimTypes.Role, "Customer")
		};

		var identity = new ClaimsIdentity(claims, "Jwt");

		return _jwtService.CreateToken(identity);
	}
}
