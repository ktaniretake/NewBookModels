using NewBookModelsSeleniumTests.POM.AccountSettings;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NewBookModelsSeleniumTests.SeleniumTests.AccountSettings
{
    public class CompanyInfoTests : TestsConfigurations
    {
        private ProfilePage _profilePage;

        [SetUp]
        public new void Setup()
        {
            var user = CreateUserViaApi();
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            _js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");
            _profilePage = new ProfilePage(_webDriver);
        }

        [Test]
        public void ChangeCompanyInformationWithValidDataTest()
        {
            _profilePage.OpenPage()
                .ClickProfileInformationEditButton()
                .SetCompanyName("CompanyName")
                .SetCompanyWebsite("alent.com")
                .SetCompanyDescription("Description")
                .ClickProfileInformationSubmitButton();

            var companyName = _webDriver.FindElement(By.CssSelector("div[class ='profile__name']"));
            var companyWebsite = _webDriver.FindElement(By.CssSelector("div[class ='profile__website'] a"));
            var companyDescription = _webDriver.FindElement(By.CssSelector("div[class ='profile__description']"));

            Assert.Multiple(() =>
            {
                Assert.AreEqual("CompanyName", companyName.Text.Trim());
                Assert.AreEqual("http://alent.com", companyWebsite.Text.Trim().ToLower());
                Assert.AreEqual("Description", companyDescription.Text.Trim());
            });
        }
    }
}
