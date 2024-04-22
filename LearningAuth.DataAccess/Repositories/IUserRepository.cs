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
/// <typeparam name="THashedPass">Used for interacting with <see cref="IUserEntity"/> implementations that have an ID and a hashed password</typeparam>
/// <typeparam name="TVisiblePass">Used for CRUD operations with <see cref="IRepository{T}"/>.</typeparam>
public interface IUserRepository<TVisiblePass> 
	: IRepository<TVisiblePass>, IUserUpdates 
	where TVisiblePass : IUser
{
	Task<IUserEntity?> Find(string username, string password);
}
