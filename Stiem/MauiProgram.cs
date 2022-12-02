using Stiem.Services;
using Stiem.View;

namespace Stiem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

            });

        builder.Services.AddSingleton<GameService>();
		builder.Services.AddSingleton<CartService>();
        builder.Services.AddSingleton<UserService>();

        builder.Services.AddSingleton<GamesViewModel>();
        builder.Services.AddSingleton<GameDetailsViewModel>();
		builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<MainPage>();
        //builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<CartPage>();
        builder.Services.AddSingleton<LoginPage>();


        return builder.Build();
	}
}
