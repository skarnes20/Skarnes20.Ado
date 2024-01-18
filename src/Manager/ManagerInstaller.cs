namespace Skarnes20.Ado.Manager;

public static class ManagerInstaller
{
    public static void AddManagerServices(this IServiceCollection service)
    {
        service.AddSingleton<IManangerSettings, SettingService>();
        service.AddSingleton<IAdoService, AdoService>();

        service.AddHttpClient();
    }

    public static void AddViewModels(this IServiceCollection service)
    {
        service.AddSingleton<SettingsViewModel>();
        service.AddTransient<TestPlanViewModel>();
    }

    public static void AddViews(this IServiceCollection service)
    {
        service.AddSingleton<SettingsPage>();
        service.AddTransient<TestPlanPage>();
    }
}