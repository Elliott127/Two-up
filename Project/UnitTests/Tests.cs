using Game.Services;
using Game.ViewModels;

namespace UnitTests
{
    public class Tests
    {
        public void Test1(GameViewModel viewModel, IUserService userService)
        {
            viewModel = new GameViewModel(userService);
            using var gvm = viewModel.Monitor();

            viewModel.Score = 0;
            viewModel.Score.Should().Be(0);
        }
    }
}