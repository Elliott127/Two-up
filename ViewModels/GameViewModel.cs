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
        private ImageSource backgroundImage;

        [ObservableProperty]
        private int score = 0;

        [ObservableProperty]
        private string scoreLabel = string.Empty;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string selection = Constants.selectionBase;

        [ObservableProperty]
        private string outcome = Constants.outcomeBase + "None";

        public GameViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task InitialiseAsync(object navigationData)
        {
            backgroundImage = "space_background.png";
            userInfo = await userService.GetUserInfo();
            Username = Constants.playerLabel + userInfo[0];
            if(score == 0)
            { 
                Score = int.Parse(userInfo[1]);
            }
            ScoreLabel = Constants.scoreBase + Score;
            Selection = Constants.selectionBase;
        }

        /// <summary>
        /// Sets theme to Dark mode
        /// </summary>
        [RelayCommand]
        public void SpaceTheme()
        {
            return;
        }

        [RelayCommand]
        public void CoinTheme()
        {
            return;
        }

        [RelayCommand]
        public void RockTheme()
        {
            return;
        }

        /// <summary>
        /// Sets isTails to true and isHeads to false
        /// </summary>
        [RelayCommand]
        private void TailsChosen()
        {
            Selection = Constants.selectionTails;
            if (isTails)
            {
                return;
            }
            isHeads = false;
            isTails = true;
        }

        /// <summary>
        /// Sets isHeads to true and isTails to false
        /// </summary>
        [RelayCommand]
        private void HeadsChosen()
        {
            Selection = Constants.selectionHeads;
            if (isHeads)
            {
                return;
            }
            isTails = false;
            isHeads = true;
        }

        /// <summary>
        /// Function designed for managing outcomes of the coins flipped
        /// </summary>
        [RelayCommand]
        private async Task TossCoin()
        {
            bool[] coins = FlipCoins();

            if (!this.isHeads && !isTails)
            {
                await App.Current.MainPage.DisplayAlert("Invalid selection", "Please make a selection", "OK");
                return;
            }
            CheckOutcome(coins);
        }

        /// <summary>
        /// Updates the ScoreLabel label for the UI so that it shows the updated score
        /// </summary>
        private void UpdateScore()
        {
            score++;
            ScoreLabel = Constants.scoreBase + score;
            userService.UpdateUserScore(score);
        }

        /// <summary>
        /// Checks to see if the player should get their score increased
        /// </summary>
        private void CheckOutcome(bool[] coins)
        {
            if (coins[0] != coins[1])
            {
                Outcome = Constants.outcomeOdd;
                return;
            }
            else if ((coins[0] && isHeads) || !coins[0] && isTails)
            {
                ResetCoins();
                UpdateScore();
                Selection = Constants.selectionBase;
            }
            Outcome = (coins[0]) ? Constants.outcomeHeads : Constants.outcomeTails;
        }

        /// <summary>
        /// Resets both isHeads and isTails values to false
        /// </summary>
        private void ResetCoins()
        {
            isHeads = false;
            isTails = false;
        }

        /// <summary>
        /// Returns two boolean values that are meant to represent the coins landing on heads or tails
        /// </summary>
        /// <returns></returns>
        private static bool[] FlipCoins()
        {
            bool[] coins = new bool[2];
            coins[0] = (RandomNumberGenerator() % 2 == 1);
            coins[1] = (RandomNumberGenerator() % 2 == 0);

            return coins;
        }

        /// <summary>
        /// <para>
        ///  Generates a number between 1 and 10
        /// </para>
        /// </summary>
        /// <returns></returns>
        private static int RandomNumberGenerator()
        {
            Random rand = new();
            return rand.Next(1,11);
        }
    }
}
