using NewBookModelsSeleniumTests.POM.SignUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace NewBookModelsSeleniumTests.SeleniumTests.SignUp
{
    public class SignUpCompanyFormTests : TestsConfigurations
    {
        private CompanySignUpPage _companySignUpPage;


        [SetUp]
        public new void Setup()
        {
            var user = CreateUserViaApi();
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            _js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");
            _companySignUpPage = new CompanySignUpPage(_webDriver);
        }

        [Test]
        public void SignUpCompanyFormFilledValidData()
        {
            _companySignUpPage.OpenPage()
                .SetCompanyName("KeanuReeves")
                .SetCompanyWebsite($"keanu{ DateTime.Now.ToString("yyyyMMddhhmmss")}.com")
                .SetCompanyAdress("222 East 41st Street, New Yo")
                .SetIndurstry("Cosmetics")
                .ClickSubmitButton();

            var actualTitle = _webDriver.FindElement(By.CssSelector("div [class^='Section__title'"));

            Assert.AreEqual("Welcome back Keanu! How can we help?", actualTitle.Text.Trim());
        }

        [Test]
        public void SignUpCompanyFormSetEmptyCompanyName()
        {
            _companySignUpPage.OpenPage()
               .SetCompanyName("")
               .SetCompanyWebsite($"keanu{ DateTime.Now.ToString("yyyyMMddhhmmss")}.com")
               .SetCompanyAdress("222 East 41st Street, New Yo")
               .SetIndurstry("Cosmetics")
               .ClickSubmitButton();

            var actualRequiredMessage = _companySignUpPage.ShowCompanyNameErrorMessage();

            Assert.AreEqual("Required", actualRequiredMessage);
        }

        [TestCase("", "Required")]
        [TestCase(".com", "Enter a valid URL.")]
        [TestCase("111", "Enter a valid URL.")]
        [TestCase("website.", "Enter a valid URL.")]
        [TestCase("!!!", "Enter a valid URL.")]
        public void SignUpCompanyFormSetInvalidCompanyWebsite(string companyWebsite, string errorMssage)
        {
            _companySignUpPage.OpenPage()
               .SetCompanyName("keanuRR")
               .SetCompanyWebsite(companyWebsite)
               .SetCompanyAdress("222 East 41st Street, New Yo")
               .SetIndurstry("Cosmetics")
               .ClickSubmitButton();

            var actualErrorMessage = _companySignUpPage.ShowCompanyWebsiteErrorMessage();

            Assert.AreEqual(errorMssage, actualErrorMessage);
        }

        [Test]
        public void SignUpCompanyFormSetEmptyCompanyAdress()
        {
            _companySignUpPage.OpenPage()
               .SetCompanyName("keanuRR")
               .SetCompanyWebsite("kreeves.com")
               .SetIndurstry("Cosmetics")
               .ClickSubmitButton();

            var actualErrorMessage = _companySignUpPage.ShowCompanyAdressErrorMessage();

            Assert.AreEqual("Please choose a location from the suggested addresses. This field doesn’t accept custom addresses, or “#” symbols.", actualErrorMessage);
        }

        [Test]
        public void SignUpCompanyFormSetEmptyIndustry()
        {
            _companySignUpPage.OpenPage()
                .SetCompanyName("KeanuReeves")
                .SetCompanyWebsite($"keanu{ DateTime.Now.ToString("yyyyMMddhhmmss")}.com")
                .SetCompanyAdress("222 East 41st Street, New Yo")
                .ClickSubmitButton();

            var actualRequiredMessage = _companySignUpPage.ShowIndustryErrorMessage();

            Assert.AreEqual("Required", actualRequiredMessage);
        }
    }
}
