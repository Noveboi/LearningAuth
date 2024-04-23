

using LearningAuth.DataAccess;
using LearningAuth.Models;

namespace LearningAuth.Client.Services;

public class RegisterService(ApiService apiService)
{
	private readonly ApiService _apiService = apiService;

	public string Message { get; set; } = string.Empty;

	public async Task<bool> RegisterAsync(UserRegisterModel user)
	{
		using var response = await _apiService.PostAsync("/register", new UserDto(user, Hasher.Hash(user.Password)));
		
		if (response.IsSuccessStatusCode == false)
		{
			Message = await response.Content.ReadAsStringAsync();
			return false;
		}

		Message = "Succesfully registered!";
		return true;
	}
}
