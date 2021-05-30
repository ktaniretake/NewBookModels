using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NewBookModelsApiTests.POM.AccountSettings
{
    public class ProfilePage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _profileInformationEditButton = By.CssSelector("div[title ='edit']");
        private static readonly By _profileInformationCancelEditButton = By.CssSelector(" div[class ^= 'settings__cancel_edit']");
        private static readonly By _companyNameField = By.CssSelector("common-input[formcontrolname = 'company_name'] input");
        private static readonly By _companyWebsiteField = By.CssSelector("common-input[formcontrolname = 'company_website'] input");
        private static readonly By _companyDescriptionField = By.CssSelector("common-textarea[formcontrolname = 'company_description'] textarea");
        private static readonly By _uploadPhotoField = By.CssSelector("div[class ^= 'profile__info'] common-button-deprecated button");
        private static readonly By _profileInformationSubmitButton = By.CssSelector("button[type = 'submit']");

        public ProfilePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ProfilePage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/profile/edit");
            return this;
        }

        public ProfilePage ClickProfileInformationEditButton()
        {
            _webDriver.FindElement(_profileInformationEditButton).Click();
            return this;
        }

        public ProfilePage ClickProfileInformationCancelEditButton()
        {
            _webDriver.FindElement(_profileInformationCancelEditButton).Click();
            return this;
        }

        public ProfilePage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }

        public ProfilePage SetCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public ProfilePage SetCompanyDescription(string companyDescription)
        {
            _webDriver.FindElement(_companyDescriptionField).SendKeys(companyDescription);
            return this;
        }

        public void ClickProfileInformationSubmitButton()
        {
            _webDriver.FindElement(_profileInformationSubmitButton).Click();
            return;
        }
    }
}
