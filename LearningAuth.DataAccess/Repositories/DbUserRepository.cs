using LearningAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories
{
	public class DbUserRepository(UsersDbContext dbContext) : IRepository<UserEntity>, IUserUpdates
	{
		private readonly UsersDbContext _dbContext = dbContext;

		public async Task Insert(IEnumerable<UserEntity> objects)
		{
			await _dbContext.Users.AddRangeAsync(objects);
		}

		public async Task<IEnumerable<UserEntity>> Read()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<UserEntity?> ReadOne(int id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
		}

		public async Task Delete(UserEntity obj)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateFirstName(int userId, string newFirstName)
		{
			throw new NotImplementedException();
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
}
