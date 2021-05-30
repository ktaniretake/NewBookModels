using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NewBookModelsApiTests.POM.SignIn
{
    public class ForgotPasswordPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _emailField = By.CssSelector("input[type ='email']");
        private static readonly By _sendResetLinkButton = By.CssSelector("button[type ='submit']");
        private static readonly By _signUpLink = By.CssSelector("div[class^='ForgotPasswordForm__signUpLink']");

        public ForgotPasswordPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ForgotPasswordPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/forgot-password");
            return this;
        }

        public ForgotPasswordPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public void ClickSendResetLinkButton()
        {
            _webDriver.FindElement(_sendResetLinkButton).Click();
        }

        public string ShowRedirectionSignUpURL()
        {
            _webDriver.FindElement(_signUpLink).Click();
            var signUpURL = _webDriver.Url;
            return signUpURL;
        }
    }
}
