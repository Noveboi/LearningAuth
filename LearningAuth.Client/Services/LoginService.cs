using Blazored.LocalStorage;
using LearningAuth.DataAccess;
using LearningAuth.Models;

using System.Net.Http.Json;

namespace LearningAuth.Client.Services;

/// <summary>
/// Interacts with the API for authentication/authorization purposes
/// </summary>
public class LoginService(ILocalStorageService localStorage, ApiService apiService, UserService userService)
{
	private readonly ILocalStorageService _localStorage = localStorage;
	private readonly ApiService _apiService = apiService;
	private readonly UserService _userService = userService;

	private const string _jwtKey = "jwtToken";

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

			if (rememberUser)
			{
				await _localStorage.SetItemAsStringAsync(_jwtKey, userWithToken.Token);
			}

			LoginMessage = $"Welcome {userWithToken.FirstName} {userWithToken.LastName}!";
			_apiService.SetAuthToken(userWithToken.Token);

			_userService.SetUser(userWithToken, userWithToken.Token);

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
		string? token = await _localStorage.GetItemAsStringAsync(_jwtKey);
		if (token != null)
		{
			_apiService.SetAuthToken(token);
		}
	}
}
