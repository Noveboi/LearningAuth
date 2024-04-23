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
public interface IUserRepository : IRepository<UserDto>, IUserUpdates 
{
	Task<IUser?> CheckExists(string username, byte[] password);
	Task<IUser?> FindByUsername(string username);
}
