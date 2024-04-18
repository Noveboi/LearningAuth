using LearningAuth.API.Authentication;
using LearningAuth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearningAuth.Tests;

public class JwtUnitTests
{

	[Fact]
	public void KeyService_EncryptsSHA256()
	{
		// Arrange
		var testKey = "hello there!";

		// Act
		var reference = SHA256.HashData(Encoding.UTF8.GetBytes(testKey));
		var test = KeyService.CreateSymmetricKey(testKey);

		// Assert
		Assert.Equal(256, test.KeySize);
		Assert.Equal(reference, test.Key);
	}

	[Fact]
	public void JwtService_CreatesNonNullToken()
	{
		// Arrange
		var testKey = "test key";
		var testIssuer = "test issuer";
		var jwtService = new JwtService(testKey, testIssuer);

		var identity = new ClaimsIdentity(new List<Claim>()
		{
			new(ClaimTypes.Name, "test user")
		});

		// Act
		var token = jwtService.CreateToken(identity);

		// Assert
		Assert.NotNull(token);
	}

	[Theory]
	[InlineData("Test User 1", "password123", "test1@gmail.com")]
	[InlineData("Test User 2", "abc1234password", "test2@yahoo.com")]
	public void JwtAuthenticator_ProducesCorrectTokenForUser(string username, string password, string email)
	{
		// Arrange
		string secret = "test key! shhhhh";
		string issuer = "http://localhost:0123";
		var jwtService = new JwtService(secret, issuer);
		var jwtAuthenticator = new JwtAuthenticator(jwtService);

		var user = new UserLoginModel()
		{
			Username = username,
			Password = password,
			Email = email
		};

		var tvp = JwtValidation.CreateParameters(secret);
		var tokenHandler = new JwtSecurityTokenHandler();

		// Act
		string token = jwtAuthenticator.CreateUserToken(user);
		ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tvp, out _);

		string? principalName = principal.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;

		// Assert
		Assert.NotNull(principalName);
		Assert.Equal(principalName, username);
	}
}

