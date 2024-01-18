namespace Skarnes20.Ado.Manager.Services;

public class AdoService : IAdoService
{
    private readonly HttpClient _client;
    private readonly IManangerSettings _settings;

    public AdoService(HttpClient client, IManangerSettings settings)
    {
        _client = client;
        _settings = settings;
    }

    public async Task<IEnumerable<TestPlan>> GetAllTestPlans()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",  await _settings.GetToken());

        var response = await _client.GetAsync($"{_settings.Organization}/{_settings.Project}/_apis/test/plans?api-version=5.0");
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
}