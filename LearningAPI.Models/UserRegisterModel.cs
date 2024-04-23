using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningAuth.Models;


namespace LearningAuth.Models;

[MetadataType(typeof(IUser))]
public class UserRegisterModel : IUser, IPasswordVisible
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Role { get; set; } = "Simple User";
	public bool IsActive { get; set; } = true;
}
