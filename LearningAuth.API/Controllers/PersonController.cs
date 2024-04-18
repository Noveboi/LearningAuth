using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningAuth.API.Controllers;

[ApiController]
public class PersonController : Controller
{
	private readonly PersonModel[] people =
	[
		new PersonModel() {FirstName = "Nikos", LastName = "Papadopoulos", Age = 40},
		new PersonModel() {FirstName = "Kostas", LastName = "Papadopoulos", Age = 20},
		new PersonModel() {FirstName = "Efthimios", LastName = "Alepis", Age = 1000},
		new PersonModel() {FirstName = "Giorgos", LastName = "Filipou", Age = 850},
		new PersonModel() {FirstName = "Timmy", LastName = "Turner", Age = 10},
		new PersonModel() {FirstName = "Alex", LastName = "Turner", Age = 88},
		new PersonModel() {FirstName = "Popy", LastName = "Franklin", Age = 2000},
		new PersonModel() {FirstName = "Maraki", LastName = "Dimitroulaki", Age = 4},
		new PersonModel() {FirstName = "George", LastName = "Farmer", Age = 3},
		new PersonModel() {FirstName = "Milly", LastName = "Taylor", Age = 20},
		new PersonModel() {FirstName = "Giannis", LastName = "Ampatziouglou", Age = 32}
	];

	[HttpGet("person/get")]
	[Authorize(AuthenticationSchemes = "Jwt")]
	public IActionResult GetRandomPerson()
	{
		return Ok(people[Random.Shared.Next(0, people.Length)]);
	}
}
