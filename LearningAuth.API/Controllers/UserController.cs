using LearningAuth.API.Authentication;
using LearningAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningAuth.API.Controllers;
[ApiController]
public class UserController(JwtAuthenticator auth) : ControllerBase
{
	private readonly JwtAuthenticator _auth = auth;

	[HttpPost("/login")]
	[AllowAnonymous]
	public IActionResult Login(UserModel user)
	{
		var token = _auth.AuthenticateUser(user);

		return Ok(token);
	}
}
