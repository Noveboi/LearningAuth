using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace LearningAuth.Client.Services;

/// <summary>
/// Serves as the middleman between other services and API calls. All HTTP related things are abstracted into this class.
/// </summary>
public class ApiService(HttpClient httpClient)
{
	private readonly HttpClient _httpClient = httpClient;
	private string? _authToken;

	public async Task<HttpResponseMessage> PostAsync<T>(string apiMethodRoute, T obj)
	{
		return await _httpClient.PostAsJsonAsync(apiMethodRoute, obj);
	}

	public async Task<HttpResponseMessage> GetAsync(string apiMethodRoute) 
	{
		return await _httpClient.GetAsync(apiMethodRoute);
	}

	public async Task<HttpResponseMessage> AuthGetAsync(string apiMethodRoute) 
	{
		var request = ConstructAuthRequest(HttpMethod.Get, apiMethodRoute);
		return await _httpClient.SendAsync(request); ;
	}

	public async Task<HttpResponseMessage> AuthPostAsync<T>(string apiMethodRoute, T obj)
	{
		var request = ConstructAuthRequest(HttpMethod.Post, apiMethodRoute, obj);
		return await _httpClient.SendAsync(request); 
	}

	public void SetAuthToken(string tokenValue) => _authToken = tokenValue;
	
	private HttpRequestMessage ConstructAuthRequest(HttpMethod method, string requestUri)
	{
		EnsureAuthTokenExists();

		var request = new HttpRequestMessage(method, requestUri);
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
		return request;
	}

	private HttpRequestMessage ConstructAuthRequest<T>(HttpMethod method, string requestUri, T obj)
	{
		EnsureAuthTokenExists();

		var request = new HttpRequestMessage(method, requestUri);
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);

		request.Content = JsonContent.Create(obj);
		return request;
	}

	private void EnsureAuthTokenExists()
	{
		if (_authToken == null)
		{
			throw new Exception("Cannot construct authorization request without a token!");
		}
	}
}
