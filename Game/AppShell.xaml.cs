using Game.Views;
namespace Game;

public partial class AppShell : Shell
{ 
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SignupView), typeof(SignupView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(GameView), typeof(GameView));

    }
}
