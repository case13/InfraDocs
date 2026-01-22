using InfraDocs.BlazorServer.Configurations;
using InfraDocs.Frontend.Configurations;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// Auth (TUDO centralizado)
builder.Services.AddAuthenticationConfiguration();
builder.Services.AddAuthorizationConfiguration();

// HttpClient
builder.Services.AddApiHttpClient(builder.Configuration);

// Services
builder.Services.AddFrontendServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
