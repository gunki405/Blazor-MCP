using Blazor_MCP;
using Blazor_MCP.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Globalization;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddLocalization();

builder.Services.AddScoped(sp =>
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("https://ywzyhyezye.execute-api.ap-northeast-1.amazonaws.com")
    };
    return client;
}); 
builder.Services.AddScoped<ChatBotService>();
builder.Services.AddSingleton<LanguageService>();

await builder.Build().RunAsync();
