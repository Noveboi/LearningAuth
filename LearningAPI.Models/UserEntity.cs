using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LearningAuth.Models;


namespace LearningAuth.Models;

[MetadataType(typeof(IUserEntity))]
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
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public byte[] PasswordHash { get; set; }
}
