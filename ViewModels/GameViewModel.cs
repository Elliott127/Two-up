using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;
using Game.ViewModels.Base;

namespace Game.ViewModels
{
    public sealed partial class GameViewModel : ViewModelBase
    {
        private readonly IUserService userService;
        private List<String> userInfo;

        [ObservableProperty]
        private int score;

        [ObservableProperty]
        private string scoreLabel = $"Score: ";

        [ObservableProperty]
        private string username = "Username: ";

        [ObservableProperty]
        private string outcome = "Outcome: ";

        public GameViewModel(IUserService userService)
        {
            this.userService = userService;

        }

        public override async Task InitialiseAsync(object navigationData)
        {
            userInfo = await userService.GetUserInfo();
            Username = userInfo[0];
            Score = int.Parse(userInfo[1]);
            ScoreLabel = ScoreLabel + Score;
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
