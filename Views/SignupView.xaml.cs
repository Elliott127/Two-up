using Game.ViewModels;

namespace Game.Views;

public partial class SignupView : ContentPage
{
	public SignupView(SignupViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}