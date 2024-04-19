using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories
{
	public class InMemoryUserRepository(UsersDbContext dbContext) : IRepository<UserLoginModel>
	{
		private readonly UsersDbContext _dbContext = dbContext;

		public void Insert(IEnumerable<UserLoginModel> objects)
		{
			throw new NotImplementedException();
		}

		public void Read()
		{
			throw new NotImplementedException();
		}

		public void ReadOne()
		{
			throw new NotImplementedException();
		}

		public void Update(UserLoginModel oldObject, UserLoginModel newObject)
		{
			throw new NotImplementedException();
		}
		public void Delete(UserLoginModel obj)
		{
			throw new NotImplementedException();
		}
	}
}
