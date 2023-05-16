using Game.Services;
using Game.Views;
using Game.ViewModels;
namespace UnitTests.ViewTests.LoginViewTests
{
    public class Tests
    {
        [Fact]
        public void Should_AssignTheViewModel_AsTheBindingContext()
        {
            var fakeService = A.Fake<IUserService>();
            var fakeViewModel = new LoginViewModel(fakeService);
            var view = new LoginView(fakeViewModel);

            view.BindingContext.Should().BeOfType<LoginViewModel>();
        }
    }
}
