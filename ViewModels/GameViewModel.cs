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
        private string scoreLabel = string.Empty;

        [ObservableProperty]
        private string username = string.Empty;

        public GameViewModel(IUserService userService)
        {
            this.userService= userService;
        }

        public void UpdateScore()
        {
            Console.WriteLine(scoreLabel);
            userService.GetUser();
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
