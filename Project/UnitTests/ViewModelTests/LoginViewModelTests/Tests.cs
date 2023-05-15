using Game.Services;
using Game.ViewModels;

namespace UnitTests.ViewModelTests.LoginViewModelTests
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var fakeUserService = A.Fake<IUserService>();
            var viewModel = new LoginViewModel(fakeUserService);
        }
    }
}
