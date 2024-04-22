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
public class DbUserRepository(UsersDbContext dbContext) : IUserRepository<IUser>
{
	private readonly UsersDbContext _dbContext = dbContext;

	public async Task<IUserEntity?> Find(string username, string password)
	{
		return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == Hasher.Hash(password));
	}

	public async Task Insert(IUser user)
	{
		await _dbContext.AddAsync(new UserEntity(user)
		{
			// Let DB handle ID auto-increment
			PasswordHash = Hasher.Hash(user.Password)
		});

		await _dbContext.SaveChangesAsync();
	}

	public async Task InsertRange(IEnumerable<IUser> users)
	{
		foreach (var user in users)
		{
			await _dbContext.AddAsync(new UserEntity(user)
			{
				// Let DB handle ID auto-increment
				PasswordHash = Hasher.Hash(user.Password)
			});
		}
		await _dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<IUser>> Read()
	{
		return await _dbContext.Users.Cast<IUser>().ToListAsync();
	}

	public async Task<IUser?> ReadOne(int userId)
	{
		return (IUser?)await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
	}

	public async Task<bool> Delete(int userId)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			_dbContext.Users.Remove(foundUser);
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

	public async Task<bool> UpdatePassword(int userId, string newPassword)
	{
		UserEntity? foundUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
		if (foundUser != null)
		{
			foundUser.PasswordHash = Hasher.Hash(newPassword);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}
}
