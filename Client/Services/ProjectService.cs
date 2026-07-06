using System.Text.Json;
using Client.Components.Models;

namespace Client.Services;

public class ProjectService : IProjectService
{
    private readonly List<ProjectModel> _projects = new();

    public ProjectService(IWebHostEnvironment environment)
    {
        var webRootPath = environment.WebRootPath;
        var filePath = Path.Combine(webRootPath, "data", "projects.json");

        if (File.Exists(filePath))
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                _projects = JsonSerializer.Deserialize<List<ProjectModel>>(jsonString, options) ?? new();
            }
            catch
            {
                // Fallback to empty list if reading/deserialization fails
            }
        }
    }

    public IReadOnlyList<ProjectModel> GetProjects() => _projects;
}
