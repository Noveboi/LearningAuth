using System.ComponentModel.DataAnnotations;

namespace LearningAuth.Models;

public class UserLoginModel : IUserLoginModel
{

	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
}
