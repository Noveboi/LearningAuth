using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines what properties/attributes a user entity should have
/// </summary>
public interface IUser
{	
	int Id { get; set; }
	string Username { get; set; }
	string FirstName { get; set; }
	string LastName { get; set; }
	byte[] Password { get; set; }
}
