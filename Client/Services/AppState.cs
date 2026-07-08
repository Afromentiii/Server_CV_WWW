public class AppState
{
    private string _currentLanguage = "PL";
    public bool ShowProjects { get; private set; } = false;
    public bool IsShowingFilter { get;  set; } = false;
    public bool IsFilterMenuOpen { get; set; } = false;
    public List<string> SelectedTechnologies { get; private set; } = new();
    public event Action? OnChange;

    public readonly Dictionary<string, string> IconToImgPath = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Python"] = "images/icons/icons8-python.svg",
        ["Unity"] = "images/icons/icons8-unity.svg",
        ["Unreal"] = "images/icons/icons8-unreal-engine.svg",
        ["Godot"] = "images/icons/icon_color.svg",
        ["C#"] = "images/icons/icons8-c-sharp-logo.svg",
        ["Colab"] = "images/icons/icons8-google-colab.svg",
        ["C++"] = "images/icons/icons8-c.svg",
        ["Java"] = "images/icons/icons8-java.svg",
        ["Neo4j"] = "images/icons/neo4j.svg",
        [".NET"] = "images/icons/icons8-.net-framework.svg",
        ["Html5"] = "images/icons/icons8-html.svg",
        ["Css"] = "images/icons/icons8-css.svg",
    };


    public string CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            if (_currentLanguage != value)
            {
                _currentLanguage = value;
                NotifyStateChanged();
            }
        }
    }
    private void NotifyStateChanged() => OnChange?.Invoke();

    public void SetLanguage(string lang)
    {
        this.CurrentLanguage = lang; 
    }

    public void ToggleProjects()
    {
        ShowProjects = !ShowProjects;
        NotifyStateChanged();
    }

    public void TurnOffFilter()
    {
        IsShowingFilter = false;
        IsFilterMenuOpen = false;
        NotifyStateChanged();
    }
    public void GoHome()
    {
        ShowProjects = false;
        TurnOffFilter();
    }

    public void ToggleFilter()
    {
        IsShowingFilter = true;
        NotifyStateChanged();
    }

    public void ToggleFilterMenu()
    {
        IsFilterMenuOpen = !IsFilterMenuOpen;
        NotifyStateChanged();
    }

    public void ToggleTechnology(string tech)
    {
        if (SelectedTechnologies.Contains(tech))
        {
            SelectedTechnologies.Remove(tech);
        }
        else
        {
            SelectedTechnologies.Add(tech);
        }
        NotifyStateChanged(); 
    }
}