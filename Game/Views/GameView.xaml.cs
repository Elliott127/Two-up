using Game.ViewModels;

namespace Game.Views;

public partial class GameView: ContentPage
{
	public GameView(GameViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var gameViewModel = this.BindingContext as GameViewModel;
		await gameViewModel.InitialiseAsync(null);
        this.SelectTheme();
    }
    private void CoinTheme(object sender, EventArgs e)
    {
        var gameViewModel = this.BindingContext as GameViewModel;
        gameViewModel.UpdateTheme("coin theme");
        this.BackgroundImageSource = "coin_background_game.png";
    }
    private void TechTheme(object sender, EventArgs e)
    {
        var gameViewModel = this.BindingContext as GameViewModel;
        gameViewModel.UpdateTheme("tech theme");
        this.BackgroundImageSource = "tech_background.png";
    }
    private void SpaceTheme(object sender, EventArgs e)
    {
        var gameViewModel = this.BindingContext as GameViewModel;
        gameViewModel.UpdateTheme("space theme");
        this.BackgroundImageSource = "space_background.png";
        
    }

    private void SelectTheme()
    {
        var gameViewModel = this.BindingContext as GameViewModel;

        switch (gameViewModel.ReadFile())
        {
            case "space theme":
                this.SpaceTheme(null, null);
                break;
            case "tech theme":
                this.TechTheme(null, null);
                break;
            case "coin theme":
                this.CoinTheme(null, null);
                break;
            default:
                this.SpaceTheme(null, null);
                break;
        }
    }
}

    