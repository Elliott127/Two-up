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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<SignupView>();
        builder.Services.AddTransient<SignupViewModel>();

        builder.Services.AddTransient<GameView>();
		builder.Services.AddTransient<GameViewModel>();

        
	
		builder.Services.AddSingleton<IUserService, UserService>();

        return builder.Build();
	}
}
