using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines the structure of the User entity used in EF Core. For a simillar user interface that doesn't have an ID and has a 
/// visible password, see <see cref="IUser"/>
/// </summary>
public interface IUserEntity : IBasicUser, IUserDetails, IPasswordHashed
{
	int Id { get; set; }
}
