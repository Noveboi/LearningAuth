using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

public interface IUserRepository<T> : IRepository<T>, IUserUpdates where T : IUser
{
	Task<bool> Exists(IUserLoginModel username);
}
