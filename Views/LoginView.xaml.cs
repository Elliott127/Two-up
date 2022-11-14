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
        username = UsernameEntry.Text;
        password = PasswordEntry.Text;
        await Navigation.PushAsync(new GamePage());
    }

    private async void OnSignupClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupView), true);
    }
    
}