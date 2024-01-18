namespace Skarnes20.Ado.Manager.Pages;

public partial class TestPlanPage : ContentPage
{
    public TestPlanPage(TestPlanViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}