using System.ComponentModel.DataAnnotations;
using LearningAuth.Models;


namespace LearningAuth.Models;

public class UserLoginModel : IBasicUser, IPasswordVisible
{

	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
}
