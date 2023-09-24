using Microsoft.Playwright.NUnit;
using PlaywrightTestsWithDotNet.Pages.CheckBoxesPage;
using PlaywrightTestsWithDotNet.Pages.LoginPage;
using PlaywrightTestsWithDotNet.Utils;
using System.Text.RegularExpressions;

namespace PlaywrightTestsWithDotNet.Tests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class CheckBoxesPageTests : PageTest
    { 
        [SetUp]
        public async Task BeforeEachTest()
        {
            await Page.GotoAsync(RunSettingsReader.BaseUrl);
            var loginPage = new LoginPage(Page);
            await loginPage.PerformLoginWithUserNameAndPassword(RunSettingsReader.UserName, RunSettingsReader.Password);
            await Expect(Page).ToHaveURLAsync(new Regex(".*home"));
        }

        [TearDown]
        public async Task AfterEachTest()
        {
            var testName = TestContext.CurrentContext.Test.Name; // Get the test name

            // Define the directory where you want to save the screenshots
            var screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

            // Ensure that the directory exists, create it if it doesn't
            Directory.CreateDirectory(screenshotDirectory);

            // Construct the full path to the screenshot file
            var screenshotPath = Path.Combine(screenshotDirectory, $"{testName}.png");

            // Capture a full-page screenshot and save it with the test name in the "Screenshots" directory
            await Page.ScreenshotAsync(new()
            {
                Path = screenshotPath,
                FullPage = true,
            });
        }

        [Test]
        public async Task ClickIndeterminateCheckBox_AllCheckboxesShouldBeClicked()
        {
            //Arrange          
            var checkBoxesPage = new CheckBoxesPage(Page);
            await checkBoxesPage.ClickNavigationMenu("Check-boxes");

            //Act
            await checkBoxesPage.WaitUntilPageIsLoaded();
            await checkBoxesPage.ClickCheckboxByName(CheckBoxNames.Indeterminate);

            //Assert
            await Expect(checkBoxesPage.GetCheckboxStatusLocator(CheckBoxNames.Indeterminate))
                .ToBeCheckedAsync();
            await Expect(checkBoxesPage.GetCheckboxStatusLocator(CheckBoxNames.Primary))
                .ToBeCheckedAsync();
            await Expect(checkBoxesPage.GetCheckboxStatusLocator(CheckBoxNames.Accent))
                .ToBeCheckedAsync();
            await Expect(checkBoxesPage.GetCheckboxStatusLocator(CheckBoxNames.Warn))
                .ToBeCheckedAsync();
        }

        [TestCase(CheckBoxNames.Primary)]
        [TestCase(CheckBoxNames.Accent)]
        [TestCase(CheckBoxNames.Warn)]
        [Ignore("Need to resolve Page isolation problem")]
        public async Task ClickCheckBox_ShouldBeClicked(CheckBoxNames checkBox)
        {
            //Arrange
            var checkBoxesPage = new CheckBoxesPage(Page);
            await checkBoxesPage.ClickNavigationMenu("Check-boxes");

            //Act
            await checkBoxesPage.WaitUntilPageIsLoaded();
            await checkBoxesPage.ClickCheckboxByName(checkBox);

            //Assert
            await Expect(checkBoxesPage.GetCheckboxStatusLocator(checkBox))
                .ToBeCheckedAsync();

            var expectedUnchecked = new List<CheckBoxNames>() { CheckBoxNames.Primary, CheckBoxNames.Accent, CheckBoxNames.Warn };
            expectedUnchecked = expectedUnchecked.Where(name => name != checkBox).ToList();

            expectedUnchecked.ForEach(async name =>
            {
                await Expect(checkBoxesPage.GetCheckboxStatusLocator(name)).ToBeCheckedAsync(new() { Checked = false });
            });       
        }        
    }
}
