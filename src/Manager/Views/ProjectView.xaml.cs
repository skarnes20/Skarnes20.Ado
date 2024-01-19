namespace Skarnes20.Ado.Manager.Views;

public partial class ProjectView
{
    public ProjectView(ProjectViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}