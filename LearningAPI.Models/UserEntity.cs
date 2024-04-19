﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public class UserEntity : IUser
{
	[Key]
	public int Id { get; set; }
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	[DataType(DataType.Password)]
	public byte[] Password { get; set; }
}