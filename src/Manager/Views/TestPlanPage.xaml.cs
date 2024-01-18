namespace Skarnes20.Ado.Manager.Views;

public partial class TestPlanPage
{
    public TestPlanPage(TestPlanViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}