using LearningAuth.API.Authentication;
using LearningAuth.API.Services;
using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningAuth.API.Controllers;
[ApiController]
public class UserController(JwtAuthenticator auth, UserService userService) : ControllerBase
{
	private readonly JwtAuthenticator _auth = auth;
	private readonly UserService _userService = userService;

	[HttpPost("/login")]
	[AllowAnonymous]
	public async Task<IActionResult> Login(LoginUserDto user)
	{
		var foundUser = await _userService.Find(user);

		if (foundUser == null)
		{
			return Unauthorized($"Wrong username or password, try again.");
		}

		var token = _auth.CreateUserToken(user);
		IUserWithToken userObjectWithToken = new UserWithToken((UserEntity)foundUser, token);

		return Ok(userObjectWithToken);
	}

	[HttpPost("/register")]
	[AllowAnonymous]
	public async Task<IActionResult> Register(UserDto user)
	{
		return Ok("Nice!");
	}
}
