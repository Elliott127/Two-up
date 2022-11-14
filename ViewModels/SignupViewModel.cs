using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;

namespace Game.ViewModels
{
    public sealed partial class SignupViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        private string username = string.Empty;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(this.ShowPasswordIncorrectError))]
        private string password = string.Empty;

        public bool ShowPasswordIncorrectError
        {
            get
            {
                return this.Password.Length < 4;
            }
        }

        public SignupViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        private async void CreateUser()
        {
            await this.userService.AddNewUser(this.Username, this.Password);
            this.Username = "";
            this.Password = "";
        }
    }
}
