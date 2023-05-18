using Game.Services;
using Game.ViewModels;
using Game.Views;
using Xunit;
using FakeItEasy;
using Microsoft.Maui.Controls;
using UnitTests.TestHelpers;

namespace Game.Tests
{
    public class LoginViewModelTests
    {
        [Fact]
        public async Task Login_WhenCredentialsAreBlank_ShouldShowInvalidInputAlert()
        {
            // Arrange
            var fakeService = A.Fake<IUserService>();
            var fakeDialogService = new FakeDialogService();
            var viewModel = new LoginViewModel(fakeService);

            // Act
            await viewModel.Login();

            // Assert
            viewModel.Password.Should().BeEmpty();
            fakeDialogService.DisplayAlertCalled.Should().BeTrue();
            fakeDialogService.DisplayAlertTitle.Should().Be("Invalid Input");
            fakeDialogService.DisplayAlertMessage.Should().Be("Not all fields are filled out");
            fakeDialogService.DisplayAlertAcceptButton.Should().Be("OK");
        }


        /*[Fact]
        public async Task Login_WhenCredentialsAreValid_ShouldNavigateToGameView()
        {
            // Arrange
            var fakeService = A.Fake<IUserService>();
            var viewModel = new LoginViewModel(fakeService);

            Application.Current.MainPage = new LoginView(viewModel);

            // Act
            viewModel.Username = "valid_username";
            viewModel.Password = "valid_password";
            await viewModel.Login();

            // Assert
            viewModel.Username.Should().BeEmpty();
            viewModel.Password.Should().BeEmpty();
            viewModel.NavigateToPage.Should().Be("GameView");
        }

        [Fact]
        public async Task Login_WhenCredentialsAreInvalid_ShouldShowInvalidCredentialsAlert()
        {
            // Arrange
            var fakeService = A.Fake<IUserService>();
            var viewModel = new LoginViewModel(fakeService);
            Application.Current.MainPage = new LoginView(viewModel);

            // Act
            viewModel.Username = "invalid_username";
            viewModel.Password = "invalid_password";
            await viewModel.Login();

            // Assert
            viewModel.Password.Should().BeEmpty();
            await Application.Current.MainPage.DisplayAlertCallCount.Should().Be(1);
            Application.Current.MainPage.DisplayAlertTitle.Should().Be("Invalid credentials");
            Application.Current.MainPage.DisplayAlertMessage.Should().Be("The credentials you entered didn't match");
            Application.Current.MainPage.DisplayAlertAccept.Should().Be("OK");
        }*/
    }
}
