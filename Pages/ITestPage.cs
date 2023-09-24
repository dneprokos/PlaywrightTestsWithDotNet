namespace PlaywrightTestsWithDotNet.Pages
{
    public interface ITestPage
    {
        Task WaitUntilPageIsLoaded();
    }
}
