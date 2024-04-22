using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines the details that a user object can optionally have.
/// </summary>
public interface IUserDetails
{
	[MaxLength(50)]
	string FirstName { get; set; }
	[MaxLength(50)]
	string LastName { get; set; }
}
