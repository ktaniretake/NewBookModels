using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace NewBookModelsApiTests.ApiTests.AccountSettings.Profile
{
    class ChangeProfileCompanyApiTests
    {
        [Test]
        public void ChangeUserProfileCompanyInfoWithValidDataApiTest()
        {
            var expectedCompanyName = "Sunny Jonson";
            var expectedCompanyURL = "http://sunnyJonson.com";
            var expectedCompanyDescription = "somthing";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);
            var userWithProfileCompanyInfo = ClientRequests.SendRequestClientProfileCompanyInfoPatch(createdUser);

            var responseModel = ClientRequests.SendRequestChangeClientProfileCompanyInfoPatch(
                expectedCompanyDescription, expectedCompanyName, expectedCompanyURL , userWithProfileCompanyInfo.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCompanyName, responseModel.Model.CompanyName);
                Assert.AreEqual(expectedCompanyURL, responseModel.Model.CompanyWebsite);
                Assert.AreEqual(expectedCompanyDescription, responseModel.Model.CompanyDescription);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserCompanyURLApiTest()
        {
            var expectedCompanyURL = "http://sunnyJonson.com";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);
            var userWithProfileCompanyInfo = ClientRequests.SendRequestClientProfileCompanyInfoPatch(createdUser);

            var responseModel = ClientRequests.SendRequestChangeClientProfileCompanyInfoPatch(
                userWithProfileCompanyInfo.User.ClientProfile.CompanyDescription, userWithProfileCompanyInfo.User.ClientProfile.CompanyName, expectedCompanyURL, userWithProfileCompanyInfo.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCompanyURL, responseModel.Model.CompanyWebsite);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserCompanyDescriptionApiTest()
        {
            var expectedCompanyDescription = "somthing new";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);
            var userWithProfileCompanyInfo = ClientRequests.SendRequestClientProfileCompanyInfoPatch(createdUser);

            var responseModel = ClientRequests.SendRequestChangeClientProfileCompanyInfoPatch(
                expectedCompanyDescription, userWithProfileCompanyInfo.User.ClientProfile.CompanyName , "ddf.com", userWithProfileCompanyInfo.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCompanyDescription, responseModel.Model.CompanyDescription);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserCompanyNameApiTest()
        {
            var expectedCompanyName = "Danny Fois";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);
            var userWithProfileCompanyInfo = ClientRequests.SendRequestClientProfileCompanyInfoPatch(createdUser);

            var responseModel = ClientRequests.SendRequestChangeClientProfileCompanyInfoPatch(
                userWithProfileCompanyInfo.User.ClientProfile.CompanyDescription, expectedCompanyName, "ddf.com", userWithProfileCompanyInfo.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCompanyName, responseModel.Model.CompanyName);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }
    }
}
