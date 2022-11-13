using Game.Repo;
using Game.Views;

namespace Game;

public partial class App : Application
{
	public static UserRepo UserRep { get; private set; }
	public App(UserRepo repo)
	{
		InitializeComponent();
		MainPage = new NavigationPage(new LoginView());
		UserRep = repo;
	}
}
