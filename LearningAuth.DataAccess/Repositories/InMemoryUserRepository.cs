using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

public class InMemoryUserRepository : IUserRepository<UserEntity>
{
	// Retain users list for the entire application lifetime
	// Fill repository with sample data
	private static readonly List<UserEntity> _users =
	[  
		new() { Id = 1, FirstName = "George", LastName = "Nikolaidis", Username = "nove", Password = SampleHashPassword("superPassword!") },
		new() { Id = 2, FirstName = "Alexandros", LastName = "Zountas", Username = "alexZu", Password = SampleHashPassword("sensei_123") },
		new() { Id = 3, FirstName = "Kostas", LastName = "Papadopoulos", Username = "kopa7", Password = SampleHashPassword("abcdef12345") },
		new() { Id = 4, FirstName = "Maria", LastName = "Dimitrouli", Username = "Mmmarry", Password = SampleHashPassword("epicMary!") }
	];

	public Task<bool> Exists(IUserLoginModel user)
	{
		
		var foundUser = _users.FirstOrDefault(u => 
		{
			return u.Username == user.Username && Enumerable.SequenceEqual(u.Password, SampleHashPassword(user.Password));
		});
		return Task.FromResult(foundUser != null);
	}

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

	private static byte[] SampleHashPassword(string passPlaintext)
	{
		return SHA256.HashData(Encoding.UTF8.GetBytes(passPlaintext));
	}
}
