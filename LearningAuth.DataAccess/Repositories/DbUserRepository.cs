using LearningAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// Contains a <see cref="UsersDbContext"/> dependency that interacts with an SQL Server database instance using EF Core.
/// </summary>
/// <param name="dbContext"></param>
public class DbUserRepository(UsersDbContext dbContext) : IUserRepository
{
	private readonly UsersDbContext _dbContext = dbContext;

	public async Task<IUser?> Find(string username, byte[] password)
	{
		return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
	}

	public async Task Insert(UserDto user)
	{
		await _dbContext.AddAsync(new UserEntity(user)
		{
			// Let DB handle ID auto-increment
			Role = user.Role,
			PasswordHash = user.PasswordHash
		});

		await _dbContext.SaveChangesAsync();
	}

	public async Task InsertRange(IEnumerable<UserDto> users)
	{
		foreach (var user in users)
		{
			await _dbContext.AddAsync(new UserEntity(user)
			{
				// Let DB handle ID auto-increment
				Role = user.Role,
				PasswordHash = user.PasswordHash
			});
		}
		await _dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<UserDto>> Read()
	{
		return await _dbContext.Users.Cast<UserDto>().ToListAsync();
	}

	public async Task<UserDto?> ReadOne(int userId)
	{
		return (UserDto?)await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
	}

	public async Task<bool> Delete(int userId)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.IsActive = false;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}

	public async Task<bool> UpdateFirstName(int userId, string newFirstName)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.FirstName = newFirstName;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}

	public async Task<bool> UpdateLastName(int userId, string newLastName)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.LastName = newLastName;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}

	public async Task<bool> UpdateUsername(int userId, string newUsername)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.Username = newUsername;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}

	public async Task<bool> UpdatePassword(int userId, byte[] newPassword)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.PasswordHash = newPassword;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}
}
