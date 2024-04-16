using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace LearningAuth.API.Authentication;

public static class KeyService
{
	public static SymmetricSecurityKey CreateSymmetricKey(string plaintext) 
	{
		byte[] encodedPlaintext = Encoding.UTF8.GetBytes(plaintext);
		byte[] hash = SHA256.HashData(encodedPlaintext);
		return new SymmetricSecurityKey(hash);
	}
}
