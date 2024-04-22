﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// Defines the necessary update operations for a repository that has objects that are a subclass of IUser.
/// </summary>
public interface IUserUpdates
{
    Task UpdateFirstName(int userId, string newFirstName);
	Task UpdateLastName(int userId, string newLastName);
	Task UpdateUsername(int userId, string newUsername);
	Task UpdatePassword(int userId, byte[] newPassword);
}
