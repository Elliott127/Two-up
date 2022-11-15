using CommunityToolkit.Mvvm.ComponentModel;
using Game.Services;

namespace Game.ViewModels
{
    public sealed partial class LoginViewModel : ObservableObject
    {
        private readonly IUserService userService;

        public LoginViewModel(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
