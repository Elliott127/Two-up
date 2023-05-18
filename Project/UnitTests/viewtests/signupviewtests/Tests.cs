using Game.Services;
using Game.ViewModels;
using Game.Views;

namespace UnitTests.ViewTests.SignupViewTests
{
    public class Tests
    {
        [Fact]
        public void Should_AssignTheViewModel_AsTheBindingContext()
        {
            var fakeService = A.Fake<IUserService>();
            var fakeViewModel = new SignupViewModel(fakeService);
            var view = new SignupView(fakeViewModel);
            view.BindingContext.Should().BeOfType<SignupViewModel>();
        }
    }
}
