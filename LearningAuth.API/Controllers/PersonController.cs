using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningAuth.API.Controllers;

[ApiController]
public class PersonController : Controller
{
	private readonly PersonModel[] people =
	[
		new PersonModel() {FirstName = "Nikos", LastName = "Papadopoulos", Age = 40},
		new PersonModel() {FirstName = "Kostas", LastName = "Papadopoulos", Age = 20},
		new PersonModel() {FirstName = "Efthimios", LastName = "Alepis", Age = 1000},
		new PersonModel() {FirstName = "Giorgos", LastName = "Filipou", Age = 850}
	];

	[HttpGet("person/get")]
	public async Task<IActionResult> GetRandomPerson()
	{
		var cookie = HttpContext.Request.Headers.Cookie.FirstOrDefault(c => c.StartsWith("auth="));

		if (cookie == null)
		{
			return Unauthorized("Login first!");
		}
		else
		{
			return Ok(people[Random.Shared.Next(0, people.Length)]);
		}
	}
}
