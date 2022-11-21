using Game.ViewModels;

namespace Game.Views;

public partial class GameView: ContentPage
{
	public GameView(GameViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var gameViewModel = this.BindingContext as GameViewModel;
		await gameViewModel.InitialiseAsync(null);
    }
}