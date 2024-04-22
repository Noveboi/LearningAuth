using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class UserWithToken : IUserWithToken
{
	[JsonConstructor]
	private UserWithToken() { }
	public UserWithToken(IUserEntity user, string token)
	{
		Id = user.Id;
		Username = user.Username;
		FirstName = user.FirstName;
		LastName = user.LastName;
		PasswordHash = user.PasswordHash;
		Token = token;
	}

	public string Token { get; set; }
	public int Id { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public byte[] PasswordHash { get; set; }
}
