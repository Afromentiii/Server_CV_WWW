using Client.Components;
using Client.Components.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var webRootPath = builder.Environment.WebRootPath;
var filePath = Path.Combine(webRootPath, "data", "projects.json");
List<ProjectModel> loadedProjects = new();

if (File.Exists(filePath))
{
    var jsonString = File.ReadAllText(filePath);
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    loadedProjects = JsonSerializer.Deserialize<List<ProjectModel>>(jsonString, options) ?? new();
}

builder.Services.AddSingleton(loadedProjects);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<AppState>();

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