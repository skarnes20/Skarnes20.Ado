namespace Skarnes20.Ado.Manager.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private readonly IManangerSettings _settings;

    public SettingsViewModel(IManangerSettings settings)
    {
        _settings = settings;
    }

    [ObservableProperty]
    private string _organization = string.Empty;

    [ObservableProperty]
    private string _project = string.Empty;

    [ObservableProperty]
    private string? _pat = string.Empty;

    [RelayCommand]
    public async Task Save()
    {
        if (!Organization.StartsWith("https"))
        {
            Organization = Organization.Insert(0, "https://dev.azure.com/");
        }
        _settings.Organization = Organization;
        _settings.Project = Project;
        await _settings.SetToken(Pat??string.Empty);
    }

    [RelayCommand]
    public async Task Appearing()
    {
        try
        {
            Organization = _settings.Organization;
            Project = _settings.Project;
            Pat = await _settings.GetToken();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}