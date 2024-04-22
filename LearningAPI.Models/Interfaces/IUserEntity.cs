using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines the structure of the User entity used in EF Core.
/// </summary>
public interface IUserEntity : IUser, IPasswordHashed
{
	int Id { get; set; }
}
