using NewBookModelsSeleniumTests.POM.AccountSettings;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace NewBookModelsSeleniumTests.SeleniumTests.AccountSettings
{
    public class AccountInfoTests : TestsConfigurations
    {
        private AccountInfoPage _accountInfoPage;

        [SetUp]
        public new void Setup()
        {
            var user = CreateUserViaApi();
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            _js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");
            _accountInfoPage = new AccountInfoPage(_webDriver);
        }

        [Test]
        public void ChangeUserGeneralInformationTest()
        {
            _accountInfoPage.OpenPage()
                .ClickGeneralInformationEditButton()
                .SetFirstNameGeneralInformationEditBlock("Billy")
                .SetLastNameGeneralInformationEditBlock("Talent")
                .SetCompanyLocationGeneralInformationEditBlock("Florida")
                .SetIndustryInformationEditBlock("Music")
                .ClickSaveChangesButtonGeneralInformationEditBlock();

            var accountHolderName = _accountInfoPage.ShowNewAccountHolderName();
            var companyLocation = _accountInfoPage.ShowNewCompanyLocation();
            var industry = _accountInfoPage.ShowNewIndustry();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Billy Talent", accountHolderName);
                Assert.AreEqual("Florida, USA", companyLocation);
                Assert.AreEqual("Music", industry);
            });
        }

        [Test]
        public void ChangeUserEmailWithValidDataTest()
        {
            var email = $"{ DateTime.Now.ToString("hhmmss")}reeves@gmail.com";

            _accountInfoPage.OpenPage()
                .ClickEmailEditButton()
                .SetCurrentPasswordEmailEditBlock(Constants.Password)
                .SetNewEmailEmailEditBlock(email)
                .ClickSaveChangesButtonEmailEditBlock();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='email-block']/div/span")));
            var newEmail = _accountInfoPage.ShowNewEmail();

            Assert.AreEqual(email, newEmail);
        }

        [TestCase("password", "keanuneanu@gmail.com", "Invalid old password.")]
        [TestCase(Constants.Password, Constants.ExistingEmail, "user with this email already exists.")]
        [TestCase("password", Constants.ExistingEmail, "Invalid old password. user with this email already exists.")]
        public void ChangeUserEmailWithInvalidDataTest(string password, string email, string expectedErrorMessage)
        {
            _accountInfoPage.OpenPage()
                .ClickEmailEditButton()
                .SetCurrentPasswordEmailEditBlock(password)
                .SetNewEmailEmailEditBlock(email)
                .ClickSaveChangesButtonEmailEditBlock();

            var erorMessage = _accountInfoPage.SeeNotificationMessage();

            Assert.AreEqual(expectedErrorMessage, erorMessage);
        }

        [Test]
        public void ChangeUserPasswordlWithValidDataTest()
        {
            _accountInfoPage.OpenPage()
               .ClickPasswordEditButton()
               .SetCurrentPasswordEditPasswordBlock(Constants.Password)
               .SetNewPasswordEditPasswordBlock("!QA2wsxc")
               .SetNewPasswordConfirmEditPasswordBlock("!QA2wsxc")
               .ClickSaveChangesButtonEditPasswordBlock();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("nb-account-info-password form div div nb-edit-switcher div[class ^= 'paragraph']")));

            Assert.Pass();
        }

        [TestCase(Constants.Password, "!@#QWE123qwe", "!@#QWE123q")]
        [TestCase(Constants.Password, "!QA2wsx", "!QA2wsx")]
        [TestCase(Constants.Password, "!QA2wsxcde34rfvbgt56yhnmju78", "!QA2wsxcde34rfvbgt56yhnmju78")]
        [TestCase(Constants.Password, "AAAaaa###", "AAAaaa###")]
        [TestCase(Constants.Password, "AAAaaa111", "AAAaaa111")]
        [TestCase(Constants.Password, "AAA111###", "AAA111###")]
        [TestCase(Constants.Password, "111###aaa", "111###aaa")]
        public void ChangeUserPasswordWithInvalidDataTest(string oldPassword, string newPassword, string newPasswordConfirm)
        {
            _accountInfoPage.OpenPage()
               .ClickPasswordEditButton()
               .SetCurrentPasswordEditPasswordBlock(oldPassword)
               .SetNewPasswordEditPasswordBlock(newPassword)
               .SetNewPasswordConfirmEditPasswordBlock(newPasswordConfirm)
               .ClickSaveChangesButtonEditPasswordBlock();

            var cancelButton = _webDriver.FindElement(By.CssSelector("nb-account-info-password form div div nb-edit-switcher div[class ^= 'paragraph']"));
            var expDisplayed = cancelButton.Displayed;

            Assert.IsTrue(expDisplayed);
        }

        [Test]
        public void ChangeUserPasswordWithInvalidOldPasswordDataTest()
        {
            _accountInfoPage.OpenPage()
               .ClickPasswordEditButton()
               .SetCurrentPasswordEditPasswordBlock("password")
               .SetNewPasswordEditPasswordBlock("!QA2wsxc")
               .SetNewPasswordConfirmEditPasswordBlock("!QA2wsxc")
               .ClickSaveChangesButtonEditPasswordBlock();

            var erorMessage = _accountInfoPage.SeeNotificationMessage();

            Assert.AreEqual("Invalid old password.", erorMessage);
        }

        [Test]
        public void ChangeUserPhoneWithValidDataTest()
        {
            _accountInfoPage.OpenPage()
               .ClickPhoneEditButton()
               .SetCurrentPasswordEditPhoneBlock(Constants.Password)
               .SetNewPhoneEditPhoneBlock("6655442255")
               .ClickSaveChangesButtonEditPhoneBlock();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("nb-account-info-phone div div nb-edit-switcher div[class ^= 'paragraph']")));
            var newPhone = _accountInfoPage.ShowNewPhone();

            Assert.AreEqual("665.544.2255", newPhone);
        }

        [Test]
        public void ChangeUserPhoneWithInvalidOldPasswordDataTest()
        {
            _accountInfoPage.OpenPage()
               .ClickPhoneEditButton()
               .SetCurrentPasswordEditPhoneBlock("jasAS@!gd2132")
               .SetNewPhoneEditPhoneBlock("6655442255")
               .ClickSaveChangesButtonEditPhoneBlock();

            var erorMessage = _accountInfoPage.SeeNotificationMessage();

            Assert.AreEqual("Invalid old password.", erorMessage);
        }

        [TestCase("12323")]
        [TestCase("")]
        [TestCase("ASDFddsds")]
        [TestCase("!@@#")]
        public void ChangeUserPhoneWithInvalidOldPasswordDataTest(string newPhone)
        {
            _accountInfoPage.OpenPage()
               .ClickPhoneEditButton()
               .SetCurrentPasswordEditPhoneBlock(Constants.Password)
               .SetNewPhoneEditPhoneBlock(newPhone)
               .ClickSaveChangesButtonEditPhoneBlock();

            var cancelButton = _webDriver.FindElement(By.CssSelector("nb-account-info-phone div div nb-edit-switcher div[class ^= 'paragraph']"));
            var cancelButtonDisplayed = cancelButton.Displayed;

            Assert.IsTrue(cancelButtonDisplayed);
        }

        [Test]
        public void LogOutClientTest()
        {
            _accountInfoPage.OpenPage()
               .ClickLogOutButton();

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches("https://newbookmodels.com/auth/signin"));
            var pageURL = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/auth/signin", pageURL);
        }
    }
}
