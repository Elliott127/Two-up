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
        private bool isHeads = false;
        private bool isTails = false;

        [ObservableProperty]
        private int score;

        [ObservableProperty]
        private string scoreLabel = string.Empty;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string selection = Constants.selectionBase;

        [ObservableProperty]
        private string outcome = Constants.outcomeBase;

        public GameViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task InitialiseAsync(object navigationData)
        {
            userInfo = await userService.GetUserInfo();
            Username = Constants.playerLabel + userInfo[0];
            Score = int.Parse(userInfo[1]);
            ScoreLabel = Constants.scoreBase + Score;
            Selection = Constants.selectionBase;
        }

        [RelayCommand]
        public void SetDarkMode()
        {
            return;
        }

        [RelayCommand]
        private void TailsChosen()
        {
            if (!isHeads && isTails)
            {
                return;
            }
            isHeads = false;
            isTails = true;
            Selection = Constants.selectionTails;
        }

        [RelayCommand]
        private void HeadsChosen()
        {
            if(!isTails && isHeads)
            {
                return;
            }
            isTails = false;
            isHeads = true;
            Selection = Constants.selectionHeads;
        }

        [RelayCommand]
        private void TossCoin()
        {
            bool isHeads = FlipCoins();

            if (!this.isHeads && !isTails)
            {
                return;
            }
            if (!isHeads)
            {
                return;
            }
            if (RandomNumberGenerator() < 50)
            {
                Outcome = Constants.outcomeHeads;
                CheckOutcome(Outcome);
                ResetCoins();
                return;
            }
            Outcome = Constants.outcomeTails;
            CheckOutcome(Outcome);
            ResetCoins();

        }

        private void CheckOutcome(string outcome)
        {
            if(isHeads && Outcome == outcome)
            {
                Score++;
            }
            else if(isTails && Outcome == outcome)
            {
                Score++;
            }
        }

        private void ResetCoins()
        {
            isHeads = false;
            isTails = false;
        }

        private bool FlipCoins()
        {
            bool coinOne = RandomNumberGenerator() < 50;
            bool coinTwo = RandomNumberGenerator() < 50;

            if (!coinOne == coinTwo)
            {
                Outcome = Constants.outcomeOdd;
                return false;
            }
            return true;
        }

        private static int RandomNumberGenerator()
        {
            Random rand = new();
            return rand.Next(0,101);
        }
    }
}
