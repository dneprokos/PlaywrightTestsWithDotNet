using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTestsWithDotNet.Models;

namespace PlaywrightTestsWithDotNet.Tests
{
    public class ApiPrototypeTest : PlaywrightTest
    {
        private IAPIRequestContext Request = null;

        [SetUp]
        public async Task SetUpAPITesting()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new ()
            {
                BaseURL = "https://restcountries.com/v2/"                
            });
        }

        [Test]
        public async Task GetCountry_ByFullName_ShouldBereturned()
        {
            //Arrange
            var countryName = "Ukraine";
            var url = $"name/{countryName}?fullText=true";

            //Act
            IAPIResponse response = await Request.GetAsync(url);

            //Assert
            Assert.IsTrue(response.Ok);
            var json = await response.JsonAsync<List<CountryApiResponseModelV2>>();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Count == 1);
            
            var country = json.First();
            Assert.AreEqual(countryName, country.name);
            Assert.AreEqual("Kyiv", country.capital);
        }
    }
}
