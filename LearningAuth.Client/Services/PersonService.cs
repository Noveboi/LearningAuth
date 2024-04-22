using LearningAuth.Models;
using System.Net.Http.Json;

namespace LearningAuth.Client.Services;

/// <summary>
/// Interacts with the API's <see cref="PersonModel"/> methods.
/// </summary>
public class PersonService(ApiService apiService)
{
	private readonly ApiService _apiService = apiService;

	public string ResultMessage { get; set; } = string.Empty;

	public async Task<PersonModel?> GetRandomPersonAsync()
	{
		ResultMessage = string.Empty;

		var response = await _apiService.AuthGetAsync("person/get");

		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<PersonModel>();
		}
		
		ResultMessage = response.StatusCode + Environment.NewLine + await response.Content.ReadAsStringAsync();
		return null;
	}
}
