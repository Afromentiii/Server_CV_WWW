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
}