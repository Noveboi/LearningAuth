using LearningAuth.API.Authentication;
using LearningAuth.API.Services;
using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;
using LearningAuth.Models.Messages;
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
		var loginResult = await _userService.Find(user);

		if (!loginResult.IsOk)
		{
			return Unauthorized(loginResult.Error!.Description);
		}

		IUser foundUser = loginResult.Data!;

		var token = _auth.CreateUserToken(user, foundUser.Role);
		IUserWithToken userObjectWithToken = new UserWithToken((UserEntity)foundUser, token);

		return Ok(userObjectWithToken);
	}

	[HttpPost("/register")]
	[AllowAnonymous]
	public async Task<IActionResult> Register(UserDto user)
	{
		var registerResult = await _userService.Register(user);

		if (!registerResult.IsOk)
		{
			return BadRequest(registerResult.Error!.Description);
		}

		return Ok();
	}
}
