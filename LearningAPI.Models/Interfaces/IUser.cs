using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines all the necessary properties a user should have along with all details (such as first and last name). 
/// This interfaces declares that the user has a visible password. For a hashed password, see <see cref="IUserEntity"/>
/// </summary>
public interface IUser : IBasicUser, IUserDetails, IPasswordVisible { }
