namespace Skarnes20.Ado.Manager.ViewModels;

public partial class TestPlanViewModel : BaseViewModel
{
    private readonly IAdoService _service;

    public TestPlanViewModel(IAdoService service)
    {
        _service = service;
    }

    public ObservableCollection<TestPlan> TestPlans { get; set; } = [];

    public ObservableCollection<object> SelectedTestPlans { get; } = [];

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

    [RelayCommand]
    async Task DeleteTestPlans()
    {
        foreach (var testPlan in SelectedTestPlans)
        {
            var plan = testPlan as TestPlan;
            if (plan != null)
            {
                    await _service.DeleteTestPlan(plan.Id);
            }
        }

        await GetTestPlans();
    }
}