namespace Skarnes20.Ado.Manager.ViewModels;

public partial class TestPlanViewModel(IAdoService service) : BaseViewModel
{
    public ObservableCollection<TestPlan> TestPlans { get; set; } = [];

    public ObservableCollection<object> SelectedTestPlans { get; } = [];

    [RelayCommand]
    async Task GetTestPlans()
    {
        var list = await service.GetAllTestPlans();
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
            if (testPlan is TestPlan plan)
            {
                await service.DeleteTestPlan(plan.Id);
            }
        }

        await GetTestPlans();
    }
}