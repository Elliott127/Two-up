using Game.Services;
using Game.ViewModels;
using Game.Views;

namespace Game;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
            });

		builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<GameView>();
		builder.Services.AddTransient<GameViewModel>();

        builder.Services.AddTransient<SignupView>();
        builder.Services.AddTransient<SignupViewModel>();

        builder.Services.AddSingleton<IUserService, UserService>();

        return builder.Build();
	}
}
