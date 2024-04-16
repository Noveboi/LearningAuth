using LearningAuth.API.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearningAuth.Tests;

public class JwtUnitTests
{
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

	[Fact]
	public void Jwt_Key
}
