namespace PlaywrightTestsWithDotNet.Utils
{
    public class RunSettingsReader
    {
        public static string BaseUrl => TestContext.Parameters["BaseUrl"]
                ?? throw new Exception("BaseUrl is not configured as a parameter.");

        public static string UserName => TestContext.Parameters["UserName"]
                ?? throw new Exception("UserName is not configured as a parameter.");

        public static string Password => TestContext.Parameters["Password"]
                ?? throw new Exception("Password is not configured as a parameter.");
    }
}
