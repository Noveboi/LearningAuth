

using LearningAuth.Models;

namespace LearningAuth.Client.Services;

public class RegisterService(ApiService apiService)
{
	private readonly ApiService _apiService = apiService;

	public string RegisterMessage { get; set; } = string.Empty;

	public async Task<bool> RegisterAsync(IUser user)
	{
		return true;
	}
}
