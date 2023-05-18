using Game.Services;
using Game.ViewModels;
using Game.Views;

namespace UnitTests.ViewTests.GameViewTests
{
    public class Tests
    {
        [Fact]
        public void Should_AssignTheViewModel_AsTheBindingContext()
        {
            var fakeService = A.Fake<IUserService>();
            var fakeViewModel = new GameViewModel(fakeService);
            var view = new GameView(fakeViewModel);
            view.BindingContext.Should().BeOfType<GameViewModel>();
        }
    }
}
