using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;
using Game.Views;

namespace Game.ViewModels
{
    public sealed partial class LoginViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty; 

        public LoginViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        private async void Login()
        {
            await Shell.Current.GoToAsync(nameof(GameView), true);
        }

        [RelayCommand]
        private async void Signup()
        {
            await Shell.Current.GoToAsync(nameof(SignupView), true);
        }
    }
}
