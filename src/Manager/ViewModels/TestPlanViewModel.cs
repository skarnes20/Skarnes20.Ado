namespace Skarnes20.Ado.Manager.ViewModels;

public partial class TestPlanViewModel : BaseViewModel
{
    private readonly IManangerSettings _settings;

    public TestPlanViewModel(IManangerSettings settings)
    {
        _settings = settings;
    }

    public ObservableCollection<TestPlan> TestPlans { get; set; } = [];

    [RelayCommand]
    async Task GetTestPlans()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://dev.azure.com/")
        };

        var auth = await _settings.GetToken();// 
        var base64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(auth));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);

        var response = await httpClient.GetAsync($"{_settings.Organization}/{_settings.Project}/_apis/test/plans?api-version=5.0");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var list = JsonSerializer.Deserialize<TestPlanList>(json, options);
            TestPlans.Clear();
            foreach (var plan in list.Value)
            {
                TestPlans.Add(plan);
            }
        }

    }
}