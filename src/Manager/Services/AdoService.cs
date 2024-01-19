namespace Skarnes20.Ado.Manager.Services;

public class AdoService : IAdoService
{
    private HttpClient _client = new();
    private readonly IManangerSettings _settings;
    private const string ApiVersion = "api-version=5.0";

    public AdoService(HttpClient client, IManangerSettings settings)
    {
        _settings = settings;
        Init(client);
    }

    private async void Init(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", await _settings.GetBase64Token());
    }

    public async Task<IEnumerable<TestPlan>> GetAllTestPlans()
    {
        var response = await _client.GetAsync($"{_settings.Organization}/{_settings.Project}/_apis/test/plans?{ApiVersion}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var list = JsonSerializer.Deserialize<TestPlanList>(json, options);
            return list == null ? [] : list.Value.ToList();
        }

        return [];
    }

    public async Task<IEnumerable<ProjectModel>> GetProjects()
    {
        var response = await _client.GetAsync($"{_settings.Organization}/_apis/projects?api-version=7.1-preview.4");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var list = JsonSerializer.Deserialize<ProjectList>(json, options);
            return list == null ? [] : list.Value.ToList();
        }

        return null;
    }

    public async Task DeleteTestPlan(int id)
    {
        _= await _client.DeleteAsync($"{_settings.Organization}/{_settings.Project}/_apis/test/plans/{id}?{ApiVersion}");
    }
}