namespace Skarnes20.Ado.Manager.ViewModels;

public partial class TestPlanViewModel(IAdoService service) : BaseViewModel
{
    public ObservableCollection<TestPlan> TestPlans { get; set; } = [];

    public ObservableCollection<object> SelectedTestPlans { get; } = [];

    [RelayCommand]
    async Task GetTestPlans()
    {
        IsBusy = true;
        TestPlans.Clear();
        try
        {
            var list = await service.GetAllTestPlans();
            App.Current.Dispatcher.Dispatch(() =>
            {
                foreach (var plan in list)
                {
                    TestPlans.Add(plan);
                }
            });

            if (!list.Any())
            {
                App.Current.MainPage.DisplayAlert("Message", "Returned no test plans.", "Ok");
            }
        }
        catch (Exception exception)
        {
            App.Current.MainPage.DisplayAlert("Ups :-(", $"Something went wrong. {exception.Message}", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task DeleteTestPlans()
    {
        var action = await App.Current.MainPage.DisplayActionSheet("Confirm delete", 
            "No", 
            "Yes", 
            $"Are you sure you want to delete {SelectedTestPlans.Count} test plans?");

        if (action is "Yes")
        {
            IsBusy = true;
            try
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
            catch (Exception exception)
            {
                App.Current.MainPage.DisplayAlert("Ups :-(", $"Something went wrong. {exception.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}