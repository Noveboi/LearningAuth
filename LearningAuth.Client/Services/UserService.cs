using LearningAuth.Models;

namespace LearningAuth.Client.Services;

/// <summary>
/// Simple service that maintains user data in application memory
/// </summary>
public class UserService
{
	public DisplayUser User { get; private set; } = default!;
	public string Role { get; private set; } = default!;

	public void SetUser(IUser user)
	{
		User = new DisplayUser()
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			Username = user.Username
		};
		Role = user.Role;
	}
}
