using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class LoginUserDto : IBasicUser, IPasswordHashed
{
	public string Username { get; set; }
	public byte[] PasswordHash { get; set; }
}
