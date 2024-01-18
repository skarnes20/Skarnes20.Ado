namespace Skarnes20.Ado.Manager.Services;

public class SettingService : IManangerSettings
{
    public string Project
    { 
        get => Preferences.Default.Get(nameof(Project), string.Empty);
        set => Preferences.Default.Set(nameof(Project), value);
    }

    public string Organization
    {
        get => Preferences.Default.Get(nameof(Organization), string.Empty);
        set => Preferences.Default.Set(nameof(Organization), value);
    }

    private readonly string _token = string.Empty;
    public async Task<string> GetToken()
    {
        return await SecureStorage.Default.GetAsync(nameof(_token)) ?? string.Empty;
    }

    public async Task<string> GetBase64Token()
    {
        var token = await SecureStorage.Default.GetAsync(nameof(_token)) ?? string.Empty;
        return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(token));
    }

    public async Task SetToken(string token)
    {
        await SecureStorage.Default.SetAsync(nameof(_token), token);
    }

    public void Clear()
    {
        Preferences.Default.Clear();
        SecureStorage.Default.RemoveAll();
    }
}