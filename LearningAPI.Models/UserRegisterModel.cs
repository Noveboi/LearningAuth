using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningAuth.Models;


namespace LearningAuth.Models;

public class UserRegisterModel : IUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
}
