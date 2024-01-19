namespace Skarnes20.Ado.Manager.ViewModels;

public partial class ProjectViewModel(IAdoService service) : BaseViewModel
{
    public ObservableCollection<object> Projects { get; set; } = [];

    [RelayCommand]
    public async Task GetProjects()
    {
        IsBusy = true;
        try
        {
            var projects = await service.GetProjects();
            Projects.Clear();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }

            if (Projects.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("Message", "No projects found.", "Ok");
            }
        }
        catch (Exception ex)
        {
            App.Current.MainPage.DisplayAlert("Ups :-(", $"Something went wrong. {ex.Message}", "Ok");
        }
        finally
        {
            IsBusy = false;
        }
    }
}