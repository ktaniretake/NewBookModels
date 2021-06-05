using NewBookModelsApiTests.Models.Auth;
using NewBookModelsSeleniumTests.POM.SignIn;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NewBookModelsSeleniumTests.SeleniumTests.SignIn
{
    public class SignInTests : TestsConfigurations
    {
        private SignInPage _signInPage;
        private ClientAuthModel _user;

        [SetUp]
        public new void Setup()
        {
            _user = CreateUserViaApi();
            _signInPage = new SignInPage(_webDriver);
        }

        [Test]
        public void SignInWithValidDataTest()
        {
            _signInPage.OpenPage()
                .SetEmail(_user.User.Email)
                .SetPassword(Constants.Password)
                .ClickLogInButton();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1[class ^= 'PageTitle']")));

            var title = _webDriver.FindElement(By.CssSelector("h1[class ^= 'PageTitle']"));

            Assert.AreEqual("Client Signup", title.Text.Trim());
        }

        [TestCase("", "Required")]
        [TestCase("email", "Invalid Email")]
        [TestCase("!@#$$%", "Invalid Email")]
        [TestCase("email@", "Invalid Email")]
        [TestCase("email.com", "Invalid Email")]
        [TestCase("@gmail.com", "Invalid Email")]
        [TestCase("email@gmail", "Invalid Email")]
        public void SignInWithInvalidEmailTest(string email, string errorMessage)
        {
            _signInPage.OpenPage()
                .SetEmail(email)
                .SetPassword(Constants.Password)
                .ClickLogInButton();

            var error = _signInPage.ShowEmailErrorMessage();

            Assert.AreEqual(errorMessage, error);
        }

        [Test]
        public void SignInWithEmptyPasswordFieldTest()
        {
            _signInPage.OpenPage()
                .SetEmail(_user.User.Email)
                .ClickLogInButton();

            var error = _signInPage.ShowPasswordErrorMessage();

            Assert.AreEqual("Required", error);
        }

        [Test]
        public void SignInWithIncorrectPasswordFieldTest()
        {
            _signInPage.OpenPage()
                .SetEmail(_user.User.Email)
                .SetPassword("sdn!@2")
                .ClickLogInButton();

            var error = _signInPage.ShowIncorrectDataErrorMessage();

            Assert.AreEqual("Please enter a correct email and password.", error);
        }

        [Test]
        public void RedirectSignUpTest()
        {
            var signUpURL = _signInPage.OpenPage()
                .ShowRedirectionSignUpURL();

            Assert.AreEqual("https://newbookmodels.com/join", signUpURL);
        }
    }
}
