using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTestsWithDotNet.Pages
{
    public class BasePage
    {
        protected readonly IPage Page;
        protected readonly PlaywrightTest Assert;

        public BasePage(IPage page)
        {
            Page = page;
            Assert = new PlaywrightTest();
        }

        public async Task ClickNavigationMenu(string menuName)
        {
            ILocator locator = Page.Locator($"a:has-text('{menuName}')");
            await locator.ClickAsync();
        }
    }
}
