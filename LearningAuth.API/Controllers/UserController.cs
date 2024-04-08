using LearningAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningAuth.API.Controllers;
[ApiController]
public class UserController : ControllerBase
{
	[HttpPost("/users/login")]
	public IActionResult Login(UserModel user)
	{
		if (user.Username == "boss" && user.Password == "vito")
		{
			return Ok("Make them an offer they can't refuse!");
		} 
		else
		{
			return Unauthorized("Revenge is a dish best served cold...");
		}
	}
}
