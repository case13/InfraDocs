using InfraDocs.BlazorServer.Authentications;
using InfraDocs.BlazorServer.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// HTTP
builder.Services.AddHttpClient();

// Auth core
builder.Services.AddAuthorizationCore();

// registra o tipo concreto
builder.Services.AddScoped<AuthStateProvider>();

// registra o contrato base apontando para o mesmo objeto
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<AuthStateProvider>()
);

// Storage seguro
builder.Services.AddScoped<ProtectedSessionStorage>();

// Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ApiHttpClient>();

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
