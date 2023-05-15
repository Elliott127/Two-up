using FluentAssertions;
using Game.Services;
using Game.ViewModels;


namespace UnitTests.ViewModelTests.GameViewModelTests
{
    public class GameViewModelTests
    {
        [Fact]
        public async Task InitialiseAsync_ShouldSetInitialValues()
        {
            // Arrange
            var fakeUserService = A.Fake<IUserService>();
            var viewModel = new GameViewModel(fakeUserService);
            var fakeUserInfo = new List<string> { "John Doe", "100" };
            A.CallTo(() => fakeUserService.GetUserInfo()).Returns(fakeUserInfo);

            // Act
            await viewModel.InitialiseAsync(null);

            // Assert
            viewModel.Username.Should().Be("Player: John Doe");
            viewModel.SelectedTheme.Should().Be("Theme Selected: SPACE THEME");
            viewModel.Score.Should().Be(100);
            viewModel.ScoreLabel.Should().Be("Score: 100");
            viewModel.Selection.Should().Be("Selection: None");
            viewModel.FirstImage.Source.Should().NotBeNull();
            viewModel.SecondImage.Source.Should().NotBeNull();
        }
    }
}
