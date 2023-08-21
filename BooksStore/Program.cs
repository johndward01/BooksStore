using Blazored.LocalStorage;
using BooksStore;
using BooksStore.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthorizationMessagingHandler>();
builder.Services.AddHttpClient("BooksStore.API", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
    .AddHttpMessageHandler<AuthorizationMessagingHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BooksStore.API"));

builder.Services.AddScoped<IBooksService, BooksHttpClientService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AppStateContainer>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("UK_Customer", policy =>
    {
        policy.RequireClaim(ClaimTypes.Country, "UK");
    });
});
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

await builder.Build().RunAsync();
