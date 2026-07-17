using Client.Components;
using Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja usługd
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddScoped<AppState>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>() 
    .AddInteractiveServerRenderMode();

app.Run();