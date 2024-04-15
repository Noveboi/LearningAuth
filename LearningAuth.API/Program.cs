using LearningAuth.API.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = "super secret key!";

builder.Services.AddScoped(sp => new JwtService(key, "http://localhost:5076"));
builder.Services.AddScoped<JwtAuthenticator>();

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
		jwtOptions.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			RequireAudience = false,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
				SHA256.HashData(Encoding.UTF8.GetBytes(key)))
		};
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
