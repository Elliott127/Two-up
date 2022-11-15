using Game.ViewModels;

namespace Game.Views;

public partial class GameView: ContentPage
{
	public GameView(GameViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}
}