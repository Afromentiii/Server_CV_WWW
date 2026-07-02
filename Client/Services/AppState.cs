public class AppState
{
    private string _currentLanguage = "PL";

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

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void SetLanguage(string lang)
    {
        this.CurrentLanguage = lang; 
    }

    public bool ShowProjects { get; private set; } = false;
    public bool IsShowingFilter { get; private set; } = false;
    public bool IsFilterMenuOpen { get; set; } = false;
    public List<string> SelectedTechnologies { get; private set; } = new();

    public void ToggleProjects()
    {
        ShowProjects = !ShowProjects;
        OnChange?.Invoke();
    }

    public void GoHome()
    {
        ShowProjects = false;
        IsShowingFilter = false;
        OnChange?.Invoke();
    }

    public void ToggleFilter()
    {
        IsShowingFilter = true;
        OnChange?.Invoke();
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