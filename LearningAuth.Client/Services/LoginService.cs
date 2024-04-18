using Blazored.LocalStorage;
using LearningAuth.Models;
using System.Net.Http.Json;

namespace LearningAuth.Client.Services;

/// <summary>
/// Interacts with the API for authentication/authorization purposes
/// </summary>
public class LoginService(ILocalStorageService localStorage, ApiService apiService)
{
	private readonly ILocalStorageService _localStorage = localStorage;
	private readonly ApiService _apiService = apiService;

	private const string _jwtKey = "jwtToken";

	/// <summary>
	/// After <see cref="Login(UserLoginModel, bool)"/> is called, an informative message about the result of the login 
	/// operation is stored in this property.
	/// </summary>
	public string LoginMessage { get; private set; } = string.Empty;

	// TODO: Return an IUser implementation
	// TODO: Return an IUser implementation
	// TODO: Return an IUser implementation
	public async Task Login(UserLoginModel user, bool rememberUser)
	{
		using var response = await _apiService.PostAsync("/login", user);

		// If the operation was succesful, the JWT token is returned.
		// Else, an error message is returned.
		string content = await response.Content.ReadAsStringAsync();

		if (response.IsSuccessStatusCode)
		{
			if (rememberUser)
			{
				await _localStorage.SetItemAsStringAsync(_jwtKey, content);
			}

			LoginMessage = $"Succesfully logged in as \"{user.Username}\"";
			_apiService.SetAuthToken(content);
		}
		else
		{
			LoginMessage = content;
		}
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
