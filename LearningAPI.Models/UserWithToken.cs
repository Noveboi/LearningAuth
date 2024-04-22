using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class UserWithToken : UserEntity, IUserWithToken
{
	public UserWithToken() { }
	public UserWithToken(IUser user, string token) : base(user)
	{
		Token = token;
	}

	public string Token { get; set; }
}
