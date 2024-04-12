using LearningAuth.API.Authentication;
using LearningAuth.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningAuth.API.Controllers;
[ApiController]
public class UserController : ControllerBase
{
	private readonly AuthenticatorService _auth;

	public UserController(AuthenticatorService auth)
	{
		_auth = auth;
	}

	[HttpPost("/users/login")]
	public IActionResult LoginAsync(UserModel user)
	{
		_auth.UserSignInCookie(user, HttpContext);

		if (user.Username == "boss" && user.Password == "vito")
		{
			return Ok("Make them an offer they can't refuse!");
		} 
		else
		{
			return Ok("Revenge is a dish best served cold...");
		}
	}
}
