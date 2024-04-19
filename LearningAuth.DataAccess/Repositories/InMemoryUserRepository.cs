using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

public class InMemoryUserRepository : IRepository<UserEntity>, IUserUpdates
{
	public Task Delete(UserEntity obj)
	{
		throw new NotImplementedException();
	}

	public Task Insert(IEnumerable<UserEntity> objects)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<UserEntity>> Read()
	{
		throw new NotImplementedException();
	}

	public Task<UserEntity?> ReadOne(int objectId)
	{
		throw new NotImplementedException();
	}

	public Task UpdateFirstName(int userId, string newFirstName)
	{
		throw new NotImplementedException();
	}

	public Task UpdateLastName(int userId, string newLastName)
	{
		throw new NotImplementedException();
	}

	public Task UpdatePassword(int userId, byte[] newPassword)
	{
		throw new NotImplementedException();
	}

	public Task UpdateUsername(int userId, string newUsername)
	{
		throw new NotImplementedException();
	}
}
