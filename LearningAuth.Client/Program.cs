using LearningAuth.Client;
using LearningAuth.Client.Authentication;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => 
{
	var client = new HttpClient
	{
		BaseAddress = new Uri("http://localhost:5076")
	};

	client.DefaultRequestHeaders.Accept.Clear();
	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

	return client;
});


// Add browser local storage for remembering the user login.
// TODO: Add refresh token
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
