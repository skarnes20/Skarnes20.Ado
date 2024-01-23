namespace Skarnes20.Ado.Manager.Infrastructure;

public class ManagerClient
{
    private HttpClient _client = new();
    private readonly IManangerSettings _settings;

    public ManagerClient(HttpClient client, IManangerSettings settings)
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

    public async Task<T> GetAsync<T>(Uri url)
    {
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var list = JsonSerializer.Deserialize<T>(json, options);
            if (list != null)
            {
                return list;
            }

            throw new Exception("Deserialization error.");
        }

        throw new Exception($"Trying to reach {url} failed with error {response.StatusCode}");
    }

    public async Task DeleteAsync(Uri url)
    {
        _ = await _client.DeleteAsync(url);
    }
}