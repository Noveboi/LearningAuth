using Microsoft.IdentityModel.Tokens;

namespace LearningAuth.API.Authentication
{

	public static class JwtValidation
	{
		public static TokenValidationParameters CreateParameters(string key) => new()
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			RequireAudience = false,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = KeyService.CreateSymmetricKey(key)
		};
	}
}
