namespace Skarnes20.Ado.Manager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddManagerServices();
        builder.Services.AddViewModels();
        builder.Services.AddViews();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
