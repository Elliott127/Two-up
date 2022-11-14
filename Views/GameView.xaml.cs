namespace Game.Views;

public partial class GamePage : ContentPage
{
	private int score;
	private int Score
	{
		get { return score; }
		set { score = value; }
	}
	public GamePage()
	{
		InitializeComponent();
		UpdateScore(0);
	}

	public void UpdateScore(int score)
	{
		Score = score;
		ScoreLabel.Text = $"Score: {Score}";
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