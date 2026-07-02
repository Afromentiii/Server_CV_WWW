public class AppState
{
    private string _currentLanguage = "PL";
    public bool ShowProjects { get; private set; } = false;
    public bool IsShowingFilter { get;  set; } = false;
    public bool IsFilterMenuOpen { get; set; } = false;
    public List<string> SelectedTechnologies { get; private set; } = new();
    public event Action? OnChange;


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