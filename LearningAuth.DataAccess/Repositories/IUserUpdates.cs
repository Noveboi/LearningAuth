using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// Defines the necessary update operations for a repository that has objects that are a subclass of IUserEntity.
/// </summary>
public interface IUserUpdates
{
    Task<bool> UpdateFirstName(int userId, string newFirstName);
	Task<bool> UpdateLastName(int userId, string newLastName);
	Task<bool> UpdateUsername(int userId, string newUsername);
	Task<bool> UpdatePassword(int userId, string newPassword);
}
