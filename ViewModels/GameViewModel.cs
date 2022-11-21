using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;
using Game.ViewModels.Base;

namespace Game.ViewModels
{
    public sealed partial class GameViewModel : ViewModelBase
    {
        private readonly IUserService userService;
        private List<string> userInfo;

        [ObservableProperty]
        private int score;

        [ObservableProperty]
        private string scoreLabel = string.Empty;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string outcome = "Outcome: ";

        public GameViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task InitialiseAsync(object navigationData)
        {
            userInfo = await userService.GetUserInfo();
            Username = "Player: " + userInfo[0];
            Score = int.Parse(userInfo[1]);
            ScoreLabel = "Score: " + Score;
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
