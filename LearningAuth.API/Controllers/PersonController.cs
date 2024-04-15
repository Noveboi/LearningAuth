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
	[Authorize(AuthenticationSchemes = "Jwt")]
	public IActionResult GetRandomPerson()
	{
		return Ok(people[Random.Shared.Next(0, people.Length)]);
	}
}
