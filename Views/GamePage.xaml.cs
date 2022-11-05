namespace Game.Views;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
		UpdateScore(0);
	}

	public void UpdateScore(int score)
	{
		ScoreLabel.Text = $"Score: {score}";
	}

	public void SetDarkMode()
	{
		throw  new NotImplementedException();
	}
}