namespace Game.Views;

public partial class LoginView : ContentPage
{
    string username;
    string password;
	public LoginView()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GamePage");
    }

    private void OnSignupClicked(object sender, EventArgs e)
    {

    }

    private void OnUsernameChanged(object sender, TextChangedEventArgs e)
    {
        username = e.NewTextValue;
    }

    private void OnPasswordChanged(object sender, TextChangedEventArgs e)
    {
        password = e.NewTextValue.ToString();
    }
}