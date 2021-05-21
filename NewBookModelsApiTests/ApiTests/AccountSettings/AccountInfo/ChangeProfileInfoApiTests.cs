using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace NewBookModelsApiTests.ApiTests.AccountSettings.AccountInfo
{
    class ChangeProfileInfoApiTests
    {
        [Test]
        public void ChangeUserProfileInfoApiTest()
        {
            var expectedIndustry = "fashion";
            var expectedLocationName = "New York";
            var expectedLocationTimezone = "America/New_York";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientProfileInfoPatch(
                expectedIndustry, expectedLocationName, expectedLocationTimezone, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedIndustry, responseModel.Model.Industry);
                Assert.AreEqual(expectedLocationName, responseModel.Model.LocationName);
                Assert.AreEqual(expectedLocationTimezone, responseModel.Model.LocationTimezone);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserIndustryApiTest()
        {
            var expectedIndustry = "fashion";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientProfileInfoPatch(
                expectedIndustry, createdUser.User.ClientProfile.LocationName, createdUser.User.ClientProfile.LocationTimezone,  createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedIndustry, responseModel.Model.Industry);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserComopanyLocationyApiTest()
        {
            var expectedLocationName = "New York";
            var expectedLocationTimezone = "America/New_York";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientProfileInfoPatch(
                createdUser.User.ClientProfile.Industry, expectedLocationName, expectedLocationTimezone, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedLocationName, responseModel.Model.LocationName);
                Assert.AreEqual(expectedLocationTimezone, responseModel.Model.LocationTimezone);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }
    }
}
