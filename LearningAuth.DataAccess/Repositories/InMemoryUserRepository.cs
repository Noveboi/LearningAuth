using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// Retains an in-memory array of user objects and implements all necessary CRUD methods.
/// </summary>
public class InMemoryUserRepository : IUserRepository
{
	// Retain users list for the entire application lifetime
	// Fill repository with sample data
	private static readonly List<UserEntity> _users =
	[  
		new() { Id = 1, FirstName = "George", LastName = "Nikolaidis", Username = "nove", PasswordHash = Hasher.Hash("superPassword!") },
		new() { Id = 2, FirstName = "Alexandros", LastName = "Zountas", Username = "alexZu", PasswordHash = Hasher.Hash("sensei_123") },
		new() { Id = 3, FirstName = "Kostas", LastName = "Papadopoulos", Username = "kopa7", PasswordHash = Hasher.Hash("abcdef12345") },
		new() { Id = 4, FirstName = "Maria", LastName = "Dimitrouli", Username = "Mmmarry", PasswordHash = Hasher.Hash("epicMary!") }
	];

	private static int _currentId = 4;

	public Task<IUser?> Find(string username, byte[] password)
	{
		var foundUser = (IUser?)_users.FirstOrDefault(u => 
		{
			return u.Username == username && Enumerable.SequenceEqual(u.PasswordHash, password);
		});

		return Task.FromResult(foundUser);
	}

	public Task Insert(UserDto user)
	{
		_currentId++;
		_users.Add(new UserEntity(user)
		{
			Id = _currentId,
			PasswordHash = user.PasswordHash
		});

		return Task.CompletedTask;
	}

	public Task InsertRange(IEnumerable<UserDto> users)
	{
		foreach (var user in users)
		{
			Insert(user);
		}

		return Task.CompletedTask;
	}

	public Task<IEnumerable<UserDto>> Read()
	{
		return Task.FromResult((IEnumerable<UserDto>)_users);
	}

	public Task<UserDto?> ReadOne(int userId)
	{
		var foundUser = _users.FirstOrDefault(u => u.Id == userId);
		UserDto? user = null;
		if (foundUser != null)
		{
			user = new UserDto(foundUser);
		}
		return Task.FromResult(user);
	}

	public Task<bool> Delete(int userId)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);
		
		if (user != null)
		{
			_currentId--;
			_users.Remove(user);
			return Task.FromResult(true);
		}

		return Task.FromResult(false);
	}


	public Task<bool> UpdateFirstName(int userId, string newFirstName)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user != null)
		{
			user.FirstName = newFirstName;
			return Task.FromResult(true);
		}

		return Task.FromResult(false);
	}

	public Task<bool> UpdateLastName(int userId, string newLastName)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user != null)
		{
			user.LastName = newLastName;
			return Task.FromResult(true);
		}

		return Task.FromResult(false);
	}

	public Task<bool> UpdatePassword(int userId, byte[] newPassword)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user != null)
		{
			user.PasswordHash = newPassword;
			return Task.FromResult(true);
		}

		return Task.FromResult(false);
	}

	public Task<bool> UpdateUsername(int userId, string newUsername)
	{
		var user = _users.FirstOrDefault(u => u.Id == userId);

		if (user != null)
		{
			user.Username = newUsername;
			return Task.FromResult(true);
		}

		return Task.FromResult(false);
	}
}
