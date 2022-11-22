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
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Password = string.Empty;
                await App.Current.MainPage.DisplayAlert("Invalid Input", "Not all fields are filled out", "OK");
                return;
            }
            else if (await userService.CheckUserCredentials(Username, Password))
            {
                await Shell.Current.GoToAsync(nameof(GameView), true);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid credentials", "The credentials you entered didn't match", "OK");
            }
            Password = string.Empty;
        }
        [RelayCommand]
        private async void Signup()
        {
            await Shell.Current.GoToAsync(nameof(SignupView), true);
        }
    }
}
