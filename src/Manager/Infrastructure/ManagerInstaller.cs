namespace Skarnes20.Ado.Manager.Infrastructure;

public static class ManagerInstaller
{
    public static void AddManagerServices(this IServiceCollection service)
    {
        service.AddSingleton<IManangerSettings, SettingService>();
        service.AddSingleton<IAdoService, AdoService>();
        service.AddSingleton<ManagerClient>();

        service.AddHttpClient();
    }

    public static void AddViewModels(this IServiceCollection service)
    {
        service.AddSingleton<SettingsViewModel>();
        service.AddTransient<TestPlanViewModel>();
        service.AddTransient<ProjectViewModel>();
    }

    public static void AddViews(this IServiceCollection service)
    {
        service.AddSingleton<SettingsPage>();
        service.AddTransient<TestPlanPage>();
        service.AddTransient<ProjectView>();
    }
}