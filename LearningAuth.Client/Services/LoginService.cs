using Blazored.LocalStorage;
using LearningAuth.DataAccess;
using LearningAuth.Models;

using System.Net.Http.Json;

namespace LearningAuth.Client.Services;

/// <summary>
/// Interacts with the API for authentication/authorization purposes
/// </summary>
public class LoginService(ApiService apiService, UserService userService)
{
	private readonly ApiService _apiService = apiService;
	private readonly UserService _userService = userService;

	/// <summary>
	/// After <see cref="Login(UserLoginModel, bool)"/> is called, an informative message about the result of the login 
	/// operation is stored in this property.
	/// </summary>
	public string LoginMessage { get; private set; } = string.Empty;

	public async Task<bool> LoginAsync(UserLoginModel user, bool rememberUser)
	{
		var dto = new LoginUserDto()
		{
			Username = user.Username,
			PasswordHash = Hasher.Hash(user.Password)
		};

		using var response = await _apiService.PostAsync("/login", dto);

		// If the operation was succesful, the user info along with the JWT Token are returned.
		// Else, an error message is returned.

		if (response.IsSuccessStatusCode)
		{
			IUserWithToken? userWithToken = await response.Content.ReadFromJsonAsync<UserWithToken>();

			if (userWithToken == null)
			{
				throw new Exception("Something went wrong, deserialized into a NULL IUserWithToken object.");
			}

			LoginMessage = $"Welcome {userWithToken.FirstName} {userWithToken.LastName}!";
			_apiService.SetAuthToken(userWithToken.Token);

			_userService.SetUser(userWithToken, userWithToken.Token);

			if (rememberUser)
			{
				await _userService.StoreToken(userWithToken.Token);
			}

			return true;
		}
		else
		{
			string content = await response.Content.ReadAsStringAsync();
			LoginMessage = content;
		}

		return false;
	}

	public async Task TryGetAuthToken()
	{
		string? token = await _userService.TryGetToken();
		if (token != null)
		{
			// Wire HttpClient to send Authorization headers with each subsequent Auth request
			_apiService.SetAuthToken(token);
		}
	}
}
