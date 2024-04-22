using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Extending interfaces declare that a user object contains the encrypted/hashed version of the password.
/// </summary>
public interface IPasswordHashed
{
	byte[] PasswordHash { get; set; }
}
