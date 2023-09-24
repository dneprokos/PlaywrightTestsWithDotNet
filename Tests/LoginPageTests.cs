using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using PlaywrightTestsWithDotNet.Utils;

namespace PlaywrightTestsWithDotNet.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task NavigateLoginPage_ShouldBeOpened()
    {
        //Arrange
        var baseUrl = RunSettingsReader.BaseUrl;

        //Act
        await Page.GotoAsync(baseUrl);

        //Assert

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("DockerJenkinsAngular"));

        var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await Expect(loginButton).ToBeAttachedAsync();
    }

    //https://playwright.dev/dotnet/docs/test-assertions
}