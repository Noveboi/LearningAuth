using System.ComponentModel.DataAnnotations;
using LearningAuth.Models;


namespace LearningAuth.Models;

[MetadataType(typeof(IBasicUser))]
public class UserLoginModel : IBasicUser, IPasswordVisible
{
	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
}
