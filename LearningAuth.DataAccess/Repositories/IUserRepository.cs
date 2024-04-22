using LearningAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess.Repositories;

/// <summary>
/// Extends the <see cref="IRepository{T}"/> pattern to include any essential login/register functionalities 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IUserRepository<T> : IRepository<T>, IUserUpdates where T : IUser
{
	Task<T?> Find(IUserLoginModel user);
}
