using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.Models.Messages;

public class Error
{
	// Restrict instantiation to this class only.
	private Error() { }

	public ErrorType Type { get; private set; }
	public string Description { get; private set; } = string.Empty;

	public static Error AlreadyExists(string description) => new()
	{
		Type = ErrorType.AlreadyExists,
		Description = description
	};

	public static Error DoesntExist(string description) => new()
	{
		Type = ErrorType.DoesntExist,
		Description = description
	};

	public static Error Unauthorized(string description) => new()
	{
		Type = ErrorType.Unauthorized,
		Description = description
	};
}

public enum ErrorType
{
	Unauthorized,
	DoesntExist,
	AlreadyExists,
	Validation,
}