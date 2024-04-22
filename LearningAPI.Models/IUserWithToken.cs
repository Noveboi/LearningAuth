using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public interface IUserWithToken : IUser
{
	string Token { get; set; }
}
