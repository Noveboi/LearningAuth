using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines all the necessary properties a user should have along with all details (such as first and last name).
/// Does NOT define how a password is represented.
/// </summary>
public interface IUser : IBasicUser, IUserDetails 
{ 
	public string Role { get; set; }
	public bool IsActive { get; set; }
}
