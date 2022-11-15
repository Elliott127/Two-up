using Game.ViewModels;

namespace Game.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext= viewModel;
	}
}