using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines the details that a user object can optionally have.
/// </summary>
public interface IUserDetails
{
	string FirstName { get; set; }
	string LastName { get; set; }
}
