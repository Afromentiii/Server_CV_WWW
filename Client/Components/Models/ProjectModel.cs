namespace Client.Components.Models
{
    public class ProjectModel
    {
        public string TitlePL { get; set; } = string.Empty;
        public string TitleEN { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public string ProjectGoalPL { get; set; } = string.Empty;
        public string ProjectGoalShortPL { get; set; } = string.Empty;
        public string ProjectGoalEN { get; set; } = string.Empty;
        public string ProjectGoalShortEN { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new();
    }
}