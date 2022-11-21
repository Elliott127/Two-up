using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;

namespace Game.ViewModels
{
    public sealed partial class GameViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        private int score = 0;

        [ObservableProperty]
        private string scoreLabel = "Score Placeholder";

        [ObservableProperty]
        private string username = "Username Placeholder";

        [ObservableProperty]
        private string outcome = "Outcome: ";

        public GameViewModel(IUserService userService)
        {
            this.userService= userService;
        }
        
        [RelayCommand]
        public void SetDarkMode()
        {
            throw new NotImplementedException();
        }
        [RelayCommand]
        private void TailsChosen()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        private void HeadsChosen()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        private void TossCoin()
        {
            throw new NotImplementedException();
        }
    }
}
