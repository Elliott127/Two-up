using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestHelpers
{
    public class FakeDialogService : IDialogService
    {
        public bool DisplayAlertCalled { get; private set; }
        public string? DisplayAlertTitle { get; private set; }
        public string? DisplayAlertMessage { get; private set; }
        public string? DisplayAlertAcceptButton { get; private set; }

        public Task DisplayAlert(string title, string message, string acceptButton)
        {
            DisplayAlertCalled = true;
            DisplayAlertTitle = title;
            DisplayAlertMessage = message;
            DisplayAlertAcceptButton = acceptButton;

            return Task.CompletedTask;
        }
    }

}

public interface IDialogService
{
    Task DisplayAlert(string title, string message, string acceptButton);
}
