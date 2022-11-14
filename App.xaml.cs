using Game.Services;
using Game.Views;

namespace Game;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
