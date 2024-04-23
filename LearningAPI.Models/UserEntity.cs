using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LearningAuth.Models;


namespace LearningAuth.Models;

public class UserEntity : IUserEntity
{ 
	public UserEntity() { }
	public UserEntity(IUser user)
	{
		Username = user.Username;
		FirstName = user.FirstName;
		LastName = user.LastName;
	}

	[Key]
	public int Id { get; set; }
	[MaxLength(20)]
	public string Username { get; set; }
	public string Role { get; set; } = "Simple User";
	[MaxLength(50)]
	public string FirstName { get; set; }
	[MaxLength(50)]

	public string LastName { get; set; }
	[DataType(DataType.Password)]
	public byte[] PasswordHash { get; set; }
	public bool IsActive { get; set; } = true;
}
