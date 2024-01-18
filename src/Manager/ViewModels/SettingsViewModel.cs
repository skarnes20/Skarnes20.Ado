namespace Skarnes20.Ado.Manager.ViewModels;

public partial class SettingsViewModel(IManangerSettings settings) : BaseViewModel
{
    [ObservableProperty]
    private string _organization = string.Empty;

    [ObservableProperty]
    private string _project = string.Empty;

    [ObservableProperty]
    private string? _pat = string.Empty;

    [RelayCommand]
    public async Task Save()
    {
        try
        {
            if (!Organization.StartsWith("https"))
            {
                Organization = Organization.Insert(0, "https://dev.azure.com/");
            }
            settings.Organization = Organization;
            settings.Project = Project;
            await settings.SetToken(Pat ?? string.Empty);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }

    [RelayCommand]
    public async Task Appearing()
    {
        try
        {
            Organization = settings.Organization;
            Project = settings.Project;
            Pat = await settings.GetToken();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    [RelayCommand]
    public void Clear()
    {
        settings.Clear();
        Organization = string.Empty;
        Project = string.Empty;
        Pat = string.Empty;
    }
}