using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class DisplayUser : IBasicUser, IUserDetails
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
}
