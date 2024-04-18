using System.ComponentModel.DataAnnotations;

namespace LearningAuth.Models;

public class UserLoginModel : IUser
{
	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
}
