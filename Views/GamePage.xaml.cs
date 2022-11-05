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

	private void OnTailsClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
	private void OnHeadsClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private void OnTossCoinClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
}