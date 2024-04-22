using LearningAuth.API.Authentication;
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
public class UserController(JwtAuthenticator auth, IUserRepository<UserEntity> repository) : ControllerBase
{
	private readonly JwtAuthenticator _auth = auth;
	private readonly IUserRepository<UserEntity> _repository = repository;

	[HttpPost("/login")]
	[AllowAnonymous]
	public async Task<IActionResult> Login(UserLoginModel user)
	{
		UserEntity? foundUser = await _repository.Find(user);

		if (foundUser == null)
		{
			return Unauthorized($"Wrong username or password, try again.");
		}

		var token = _auth.CreateUserToken(user);
		IUserWithToken userObjectWithToken = new UserWithToken(foundUser, token);

		return Ok(userObjectWithToken);
	}
}
