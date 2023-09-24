using Microsoft.Playwright;

namespace PlaywrightTestsWithDotNet.Pages.LoginPage
{
    public class LoginPage : BasePage, ITestPage
    {
        private readonly ILocator _loginBtn;
        private readonly ILocator _userNameInput;
        private readonly ILocator _userPasswordInput;

        public LoginPage(IPage page) : base(page)
        {
            _loginBtn = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            _userNameInput = Page.GetByText("Username");
            _userPasswordInput = Page.GetByText("Password", new() { Exact = true });
        }

        public async Task WaitUntilPageIsLoaded()
        {
            await Assert.Expect(_loginBtn).ToBeAttachedAsync();
        }

        public async Task FillTextToUserNameField(string text)
        {
            await _userNameInput.FillAsync(text, new() { Force = true });
        }

        public async Task FillTextToPasswordField(string text)
        {
            await _userPasswordInput.FillAsync(text, new() { Force = true });
        }

        public async Task ClickLoginBtn()
        {
            await _loginBtn.ClickAsync();
        }

        public async Task PerformLoginWithUserNameAndPassword(string userName, string password)
        {
            await WaitUntilPageIsLoaded();
            await FillTextToUserNameField(userName);
            await FillTextToPasswordField(password);
            await _loginBtn.ClickAsync();
        }
    }
}
