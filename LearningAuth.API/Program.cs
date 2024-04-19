using LearningAuth.API.Authentication;
using LearningAuth.DataAccess.Repositories;
using LearningAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = builder.Configuration["secretKey"] ?? throw new Exception("Key not found in user secrets!");

builder.Services.AddScoped(sp => new JwtService(key, "http://localhost:5076"));
builder.Services.AddScoped<JwtAuthenticator>();
builder.Services.AddScoped<IRepository<UserEntity>, InMemoryUserRepository>();

// Add CORS service to allow cross-origin requests
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowWasm", policy =>
	{
		policy.WithOrigins("http://localhost:5006")
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

builder.Services.AddAuthentication("Jwt")
	.AddCookie("Cookie", cookieOptions =>
	{
		cookieOptions.Cookie.Name = "auth-cookie";
		cookieOptions.Cookie.SameSite = SameSiteMode.None;
		cookieOptions.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	})
	.AddJwtBearer("Jwt", jwtOptions => 
	{
		// Override the OnMessageReceived handler to manually set the JWT for the MessageReceivedContext.
		// This is done because the MessageReceivedContext.Token is null if we do not assign it below. Thus, 
		// the JwtBearerHandler will not be able to succesfully authenticate.
		jwtOptions.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents()
		{
			OnMessageReceived = ctx =>
			{
				var authorization = ctx.Request.Headers.Authorization;
				if (authorization.Count != 0)
				{
					// Manually set the context token
					var token = authorization.ToString()[6..].Trim().Replace("\"", null);
					ctx.Token = token;
				}

				return Task.CompletedTask;
			},
			OnAuthenticationFailed = ctx =>
			{
				// Check if authentication failed due to token expiring.
				if (ctx.Exception is SecurityTokenExpiredException ex)
				{
					// TODO: Create a new token
					// How to access JwtAuthenticator service in here?
				}

				return Task.CompletedTask;
			},
		};

		jwtOptions.TokenValidationParameters = JwtValidation.CreateParameters(key);
	});

var app = builder.Build();

app.UseCors("AllowWasm")
	.UseAuthentication()
	.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
