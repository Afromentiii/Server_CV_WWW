namespace Client.Components.Models
{
    public class ProjectModel
    {
        public string TitlePL { get; set; } = string.Empty;
        public string TitleEN { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new();
    }
}