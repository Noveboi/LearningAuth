using LearningAuth.API.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthenticatorService>();

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

var app = builder.Build();

app.UseCors("AllowWasm");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
