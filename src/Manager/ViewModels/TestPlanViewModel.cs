namespace Skarnes20.Ado.Manager.ViewModels;

public partial class TestPlanViewModel : BaseViewModel
{
    private readonly IManangerSettings _settings;
    private readonly IAdoService _service;

    public TestPlanViewModel(IManangerSettings settings, IAdoService service)
    {
        _settings = settings;
        _service = service;
    }

    public ObservableCollection<TestPlan> TestPlans { get; set; } = [];

    [RelayCommand]
    async Task GetTestPlans()
    {
        var list = await _service.GetAllTestPlans();
        TestPlans.Clear();
        foreach (var plan in list)
        {
            TestPlans.Add(plan);
        }
    }
}