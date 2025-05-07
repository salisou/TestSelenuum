using Microsoft.Extensions.Logging;
using OnlineCourseUIDesigns.MVVM.ViewModels;
using OnlineCourseUIDesigns.MVVM.Views;
using OnlineCourseUIDesigns.Services;

namespace OnlineCourseUIDesigns
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("BebasNeue-Regular.ttf", "OpenSansRegular");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ClothFashionService>();

            builder.Services.AddSingleton<WelcomeViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<DetailViewModel>();

            builder.Services.AddSingleton<WelcomeView>();
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<DetailView>();

            return builder.Build();
        }
    }
}
