using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class UserWithToken : IUserWithToken
{
	public UserWithToken(UserEntity user, string token)
	{
		User = user;
		Token = token;
	}

	public UserEntity User { get; set; }
	public string Token { get; set; }
}
