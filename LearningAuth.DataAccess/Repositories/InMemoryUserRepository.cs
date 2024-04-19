using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

public class InMemoryUserRepository : IRepository<UserEntity>, IUserUpdates
{
	private readonly List<UserEntity> _users = [];

	public Task Insert(IEnumerable<UserEntity> users)
	{
		_users.AddRange(users);
		return Task.CompletedTask;
	}

	public Task<IEnumerable<UserEntity>> Read()
	{
		return Task.FromResult((IEnumerable<UserEntity>)_users);
	}

	public Task<UserEntity?> ReadOne(int userId)
	{
		return Task.FromResult(_users.FirstOrDefault(u => u.Id == userId));
	}

	public Task Delete(int userId)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);
		
		if (user == default)
		{
			return Task.CompletedTask;
		}

		_users.Remove(user);
		return Task.CompletedTask;
	}


	public Task UpdateFirstName(int userId, string newFirstName)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user == default)
		{
			return Task.CompletedTask;
		}

		user.FirstName = newFirstName;
		return Task.CompletedTask;
	}

	public Task UpdateLastName(int userId, string newLastName)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user == default)
		{
			return Task.CompletedTask;
		}

		user.LastName = newLastName;
		return Task.CompletedTask;
	}

	public Task UpdatePassword(int userId, byte[] newPassword)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user == default)
		{
			return Task.CompletedTask;
		}

		user.Password = newPassword;
		return Task.CompletedTask;

	}

	public Task UpdateUsername(int userId, string newUsername)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user == default)
		{
			return Task.CompletedTask;
		}

		user.Username = newUsername;
		return Task.CompletedTask;
	}
}
