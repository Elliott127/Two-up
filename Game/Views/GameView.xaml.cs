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
    private void CoinTheme(object sender, EventArgs e)
    {
        this.BackgroundImageSource = "coin_background_game.png";
    }
    private void TechTheme(object sender, EventArgs e)
    {
        this.BackgroundImageSource = "tech_background.png";
    }
    private void SpaceTheme(object sender, EventArgs e)
    {
        this.BackgroundImageSource = "space_background.png";
        
    }
}

    