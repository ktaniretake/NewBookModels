using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NewBookModelsSeleniumTests.POM.SignIn
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _emailField = By.CssSelector("input[type=email]");
        private static readonly By _passwordField = By.CssSelector("input[type=password]");
        private static readonly By _logInButton = By.CssSelector("button[type=submit]");
        private static readonly By _signUpRedirectionButton = By.CssSelector("div[class^= 'SignInForm__signUpLink']");
        private static readonly By _forgotPasswordRedirection = By.CssSelector("a[class ^= 'SignInPage__forgotPassword']");
        private static readonly By _emailErrorMessage = By.XPath(".//input[@type='email']/../div/div");
        private static readonly By _passwordErrorMessage = By.XPath(".//input[@type='password']/../div/div");
        private static readonly By _incorrectDataErrorMessage = By.CssSelector("div [class ^='PageFormLayout'] div[class ^= 'FormErrorText']");

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public SignInPage ClickLogInButton()
        {
            _webDriver.FindElement(_logInButton).Click();
            return this;
        }

        public string ShowRedirectionSignUpURL()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriver.FindElement(_signUpRedirectionButton).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://newbookmodels.com/join"));
            var signUpURL = _webDriver.Url;
            return signUpURL;
        }

        public string ShowRedirectionForgotPasswordURL()
        {
            _webDriver.FindElement(_forgotPasswordRedirection).Click();
            var signUpURL = _webDriver.Url;
            return signUpURL;
        }
        public string ShowEmailErrorMessage()
        {
            return _webDriver.FindElement(_emailErrorMessage).Text;
        }

        public string ShowPasswordErrorMessage()
        {
            return _webDriver.FindElement(_passwordErrorMessage).Text;
        }

        public string ShowIncorrectDataErrorMessage()
        {
            return _webDriver.FindElement(_incorrectDataErrorMessage).Text;
        }
    }
}
