﻿using LearningAuth.Models;
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
public class DbUserRepository(UsersDbContext dbContext) : IUserRepository<UserEntity>
{
	private readonly UsersDbContext _dbContext = dbContext;

	public async Task<UserEntity?> Find(IUserLoginModel user)
	{

	}

	public async Task Insert(IEnumerable<UserEntity> objects)
	{
		await _dbContext.Users.AddRangeAsync(objects);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<UserEntity>> Read()
	{
		return await _dbContext.Users.ToListAsync();
	}

	public async Task<UserEntity?> ReadOne(int id)
	{
		return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
	}

	public async Task Delete(int userId)
	{
		UserEntity? foundUser = await ReadOne(userId);
		if (foundUser != null)
		{
			_dbContext.Users.Remove(foundUser);
			await _dbContext.SaveChangesAsync();
		}
	}

	public async Task UpdateFirstName(int userId, string newFirstName)
	{
		await _dbContext.Users.Exw
	}

	public async Task UpdateLastName(int userId, string newLastName)
	{
		throw new NotImplementedException();
	}

	public async Task UpdateUsername(int userId, string newUsername)
	{
		throw new NotImplementedException();
	}

	public async Task UpdatePassword(int userId, byte[] newPassword)
	{
		throw new NotImplementedException();
	}
}
