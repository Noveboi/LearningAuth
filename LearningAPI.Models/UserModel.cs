using System.ComponentModel.DataAnnotations;

namespace LearningAuth.Models;

public class UserModel : IUser
{
	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	[Required]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; }
}
