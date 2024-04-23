using Blazored.LocalStorage;
using LearningAuth.Models;
using System.Data;
using System.Net.Http.Json;

namespace LearningAuth.Client.Services;

/// <summary>
/// Simple service that maintains user data in application memory
/// </summary>
public class UserService(ILocalStorageService localStorage, ApiService apiService)
{
	private readonly ILocalStorageService _localStorage = localStorage;
	private readonly ApiService _apiService = apiService;
	internal const string _jwtKey = "jwtToken";

	public DisplayUser User { get; private set; } = default!;
	public string Role { get; private set; } = default!;
	public string Token { get; private set; } = default!;

	public bool CanRequestDetails { get; private set; } = true;

	public void SetUser(IUser user, string jwt)
	{
		User = new DisplayUser()
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			Username = user.Username
		};
		Role = user.Role;
		Token = jwt;

		CanRequestDetails = false;
	}

	public async Task<bool> RequestUserDetails()
	{
		if (Token == null)
		{
			var token = await TryGetToken();

			if (token == null)
			{
				throw new Exception("Cannot request user details without having a JWT");
			}

			Token = token;
		}
		if (CanRequestDetails == false)
		{
			return false;
		}

		// Ensure token is set in ApiService
		_apiService.SetAuthToken(Token);

		using var response = await _apiService.AuthGetAsync("/requestDetails");

		if (response.IsSuccessStatusCode)
		{
			var detailedUser = await response.Content.ReadFromJsonAsync<UserDto>() 
				?? throw new Exception("Unexpected behavior: Deserialized detailedUser into NULL.");

			User = new DisplayUser()
			{
				FirstName = detailedUser.FirstName,
				LastName = detailedUser.LastName,
				Username = detailedUser.Username
			};

			Role = detailedUser.Role;

			CanRequestDetails = false;
			return true;
		}
		else
		{
			// Log that detail retrieval has failed.
			return false;
		}
	}

	public async Task StoreToken(string token) => await _localStorage.SetItemAsStringAsync(_jwtKey, token);
	public async Task<string?> TryGetToken() => await _localStorage.GetItemAsStringAsync(_jwtKey);
}
