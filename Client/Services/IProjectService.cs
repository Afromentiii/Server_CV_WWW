using Client.Components.Models;

namespace Client.Services;

public interface IProjectService
{
    IReadOnlyList<ProjectModel> GetProjects();
}
