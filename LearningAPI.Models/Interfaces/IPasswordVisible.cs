﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public interface IPasswordVisible
{
	[DataType(DataType.Password)]
	string Password { get; set; }
}
