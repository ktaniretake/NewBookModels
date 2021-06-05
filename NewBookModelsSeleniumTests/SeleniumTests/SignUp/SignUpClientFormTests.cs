using NewBookModelsSeleniumTests.POM.SignUp;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace NewBookModelsSeleniumTests.SeleniumTests.SignUp
{
    public class SignUpClientFormTests : TestsConfigurations
    {
        private ClientSignUpPage _clientSignUpPage;

        [SetUp]
        public new void Setup()
        {
            _clientSignUpPage = new ClientSignUpPage(_webDriver);
        }

        [Test]
        public void SignUpClientFormFilledValidData()
        {
            _clientSignUpPage.OpenPage()
                .SetFirstName(Constants.FirstName)
                .SetLastName(Constants.LastName)
                .SetEmail($"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com")
                .SetPassword(Constants.Password)
                .SetConfirmPassword(Constants.Password)
                .SetPhone(Constants.Phone)
                .ClickNextButton();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://newbookmodels.com/join/company"));
            var actualH2Title = _webDriver.FindElement(By.CssSelector("h2[class ^= 'SignupAvatar']"));

            Assert.AreEqual("Final step!", actualH2Title.Text.Trim());
        }

        [TestCase("email")]
        [TestCase("!@#$$%")]
        [TestCase("email@")]
        [TestCase("email.com")]
        [TestCase("@gmail.com")]
        [TestCase("email@gmail")]
        public void SignUpClientFormSetInvalidEmail(string email)
        {
            _clientSignUpPage.OpenPage()
                .SetFirstName(Constants.FirstName)
                .SetLastName(Constants.LastName)
                .SetEmail(email)
                .SetPassword(Constants.Password)
                .SetConfirmPassword(Constants.Password)
                .SetPhone(Constants.Phone)
                .ClickNextButton();

            var errorMessage = _clientSignUpPage.SeeErrorMessageNearField("Invalid Email");

            Assert.AreEqual("Invalid Email", errorMessage);
        }

        [TestCase("!QA2wsx")]
        [TestCase("!QA2wsxcde34rfvbgt56yhnmju78")]
        [TestCase("AAAaaa###")]
        [TestCase("AAAaaa111")]
        [TestCase("AAA111###")]
        [TestCase("111###aaa")]
        public void SignUpClientFormSetInvalidPassword(string password)
        {
            _clientSignUpPage.OpenPage()
                .SetFirstName(Constants.FirstName)
                .SetLastName(Constants.LastName)
                .SetEmail($"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com")
                .SetPassword(password)
                .SetConfirmPassword(Constants.Password)
                .SetPhone(Constants.Phone)
                .ClickNextButton();

            var errorMessage = _clientSignUpPage.SeeErrorMessageNearField("Invalid password format");

            Assert.AreEqual("Invalid password format", errorMessage);
        }

        [Test]
        public void SignUpClientFormSetIncorrectConfirmPassword()
        {
            _clientSignUpPage.OpenPage()
                 .SetFirstName(Constants.FirstName)
                 .SetLastName(Constants.LastName)
                 .SetEmail($"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com")
                 .SetPassword(Constants.Password)
                 .SetConfirmPassword("kdbka")
                 .SetPhone(Constants.Phone)
                 .ClickNextButton();

            var errorMessage = _clientSignUpPage.SeeErrorMessageNearField("Passwords must match");

            Assert.AreEqual("Passwords must match", errorMessage);
        }

        [TestCase("333666999")]
        [TestCase("0")]
        [TestCase("phonenumber")]
        [TestCase("********")]
        public void SignUpClientFormSetInvalidPhone(string phone)
        {
            _clientSignUpPage.OpenPage()
                .SetFirstName(Constants.FirstName)
                .SetLastName(Constants.LastName)
                .SetEmail($"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com")
                .SetPassword(Constants.Password)
                .SetConfirmPassword(Constants.Password)
                .SetPhone(phone)
                .ClickNextButton();

            var errorMessage = _clientSignUpPage.SeeErrorMessageNearField("Invalid phone format");

            Assert.AreEqual("Invalid phone format", errorMessage);
        }

        [Test]
        public void RedirectSignInTest()
        {
            var redirectionUrl = _clientSignUpPage.OpenPage()
                .ShowRedirectionSignInURL();

            Assert.AreEqual("https://newbookmodels.com/auth/signin", redirectionUrl);
        }
    }
}
