using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Used for sending JSON Data from Client to API
/// </summary>
public class UserDto : IUser, IPasswordHashed
{
	[JsonConstructor]
	private UserDto() { }
	public UserDto(IUserEntity userEntity)
	{
		Username = userEntity.Username;
		FirstName = userEntity.FirstName;
		LastName = userEntity.LastName;
		PasswordHash = userEntity.PasswordHash;
	}

	public byte[] PasswordHash { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public static explicit operator UserDto?(UserEntity? userEntity)
	{
		if (userEntity == null)
			return null;

		return new UserDto(userEntity);
	}
}
