using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

public interface IPasswordVisible
{
	string Password { get; set; }
}
