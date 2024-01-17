namespace Skarnes20.Ado.Manager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"///settings");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ups: {ex.Message}");
        }
    }
}
