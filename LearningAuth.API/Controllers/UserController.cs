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
		var loginResult = await _userService.CheckExists(user);

		if (!loginResult.IsOk)
		{
			return Unauthorized(loginResult.Error!.Description);
		}

		IUser foundUser = loginResult.Data!;

		var token = _auth.CreateUserToken(user, foundUser.Role);
		IUserWithToken userObjectWithToken = new UserWithToken((UserEntity)foundUser, token);

		return Ok(userObjectWithToken);
	}

	/// <summary>
	/// USE CASE: 
	///		When a user has a JWT Token available without logging in (e.g. local storage). They send out a 
	///		request details request to get all the necessary user info they need for their client.
	/// </summary>
	/// <returns></returns>
	[HttpGet("/requestDetails")]
	[Authorize]
	public async Task<IActionResult> RequestUserDetails()
	{
		var userIdentity = User.Identity;

		if (userIdentity != null)
		{
			var username = userIdentity.Name;
			if (username != null)
			{
				var findResult = await _userService.FindByUsername(username);
				
				if (findResult.IsOk == false)
				{
					return BadRequest(findResult.Error!.Description);
				}

				return Ok(findResult.Data!);
			}

			return BadRequest("User identity has null username");
		}

		return BadRequest("User doesn't have an identity");
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
