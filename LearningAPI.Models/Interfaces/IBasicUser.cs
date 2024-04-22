using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models;

/// <summary>
/// Defines the most basic properties that a user must have
/// </summary>
public interface IBasicUser
{
	string Username { get; set; }
}
