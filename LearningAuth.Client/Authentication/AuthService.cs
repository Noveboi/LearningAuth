namespace LearningAuth.Client.Authentication;

public class AuthService
{
	private const string authCookiePrefix = "auth=";

	public string? AuthCookie { get; private set; } 

	public void GetAuthCookie(HttpResponseMessage response)
	{
		if (response.Headers.Contains("Set-Cookie") == false)
		{
			throw new Exception("Response header does not contain \'Set-Cookie\'");
		}
		else
		{
			IEnumerable<string> cookies = response.Headers.GetValues("Set-Cookie");
			var cookie = cookies.FirstOrDefault(ck => ck.StartsWith(authCookiePrefix));

			if (cookie == null)
			{
				throw new Exception("Auth Cookie not found.");
			}

			AuthCookie = cookie;
		}
	}
}
