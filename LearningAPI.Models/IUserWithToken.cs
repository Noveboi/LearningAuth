using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Used for transferring data between API and client when logging in.
/// </summary>
public interface IUserWithToken 
{
	UserEntity User { get; set; }
	string Token { get; set; }
}
