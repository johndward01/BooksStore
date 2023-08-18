using Blazored.LocalStorage;
using BooksStore;
using BooksStore.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IBooksService, LocalBooksService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AppStateContainer>();

await builder.Build().RunAsync();
