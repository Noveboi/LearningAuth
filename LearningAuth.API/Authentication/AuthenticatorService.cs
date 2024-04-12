using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;

namespace LearningAuth.API.Authentication;

public class AuthenticatorService
{
	/// <summary>
	/// Authenticate user using Claims library. Additionally assign a role to the user for authorization.
	/// </summary>
	public async Task UserSignInClaim(UserModel user, string role, HttpContext context)
	{
		var claims = new List<Claim>()
		{
			new(ClaimTypes.Name, user.Username),
			new(ClaimTypes.Role, role)
		};

		var claimsId = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var authProperties = new AuthenticationProperties()
		{
			AllowRefresh = true,
			ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),
			IsPersistent = false,
			IssuedUtc = DateTimeOffset.Now,
		};

		await context.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			new ClaimsPrincipal(claimsId),
			authProperties);
	}

	/// <summary>
	/// Manually implemented simple cookie auth.
	/// </summary>
	/// <returns></returns>
	public void UserSignInCookie(UserModel user, HttpContext context)
	{
		// Knead the cookie dough.
		string cookieValue = $"auth={user.Username}";

		// Bake the cookie and put it in delivery truck.
		context.Response.Headers.SetCookie = cookieValue;
	}
}
