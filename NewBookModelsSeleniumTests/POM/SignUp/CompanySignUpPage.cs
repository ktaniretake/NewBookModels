using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NewBookModelsSeleniumTests.POM.SignUp
{
    public class CompanySignUpPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _companyNameField = By.CssSelector("input[name = 'company_name']");
        private static readonly By _companyWebsiteField = By.CssSelector("input[name = 'company_website']");
        private static readonly By _companyAdressField = By.CssSelector("input[name = 'location']");
        private static readonly By _firstElementAdressDropdown = By.CssSelector("div[class ='pac-item']");
        private static readonly By _industryDropdown = By.CssSelector("input[name ='industry']");
        private static readonly By _submitButton = By.CssSelector("button[class ^='SignupCompanyForm']");
        private static readonly By _companyNameErrorMessage = By.XPath($".//input[@name ='company_name']/../div[@class = 'FormErrorText__error---nzyq']");
        private static readonly By _companyWebsiteErrorMessage = By.XPath(".//input[@name ='company_website']/../div/div");
        private static readonly By _companyAdressErrorMessage = By.XPath($".//input[@name ='location']/../div[@class = 'FormErrorText__error---nzyq']");
        private static readonly By _industryErrorMessage = By.XPath($".//input[@name ='industry']/../../div[@class = 'FormErrorText__error---nzyq']");

        public CompanySignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CompanySignUpPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore");
            return this;
        }

        public CompanySignUpPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }

        public CompanySignUpPage SetCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public CompanySignUpPage SetCompanyAdress(string companyAdress)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriver.FindElement(_companyAdressField).SendKeys(companyAdress);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_firstElementAdressDropdown));
            _webDriver.FindElement(_firstElementAdressDropdown).Click();
            return this;
        }

        public CompanySignUpPage SetIndurstry(string industry)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriver.FindElement(_industryDropdown).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(), '{industry}')]")));
            _webDriver.FindElement(By.XPath($"//span[contains(text(), '{industry}')]")).Click();
            return this;
        }

        public void ClickSubmitButton()
        {
            _webDriver.FindElement(_submitButton).Click();
            return;
        }

        public string ShowCompanyNameErrorMessage()
        {
            return _webDriver.FindElement(_companyNameErrorMessage).Text;
        }

        public string ShowCompanyWebsiteErrorMessage()
        {
            return _webDriver.FindElement(_companyWebsiteErrorMessage).Text;
        }

        public string ShowCompanyAdressErrorMessage()
        {
            return _webDriver.FindElement(_companyAdressErrorMessage).Text;
        }

        public string ShowIndustryErrorMessage()
        {
            return _webDriver.FindElement(_industryErrorMessage).Text;
        }
    }
}
