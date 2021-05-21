using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace NewBookModelsApiTests.ApiTests.AccountSettings.AccountInfo
{
    class ChangeSelfInfoApiTests
    {
        [Test]
        public void ChangeUserSelfInfoApiTest()
        {
            var expectedFirstName = "Sunny";
            var expectedLastName = "Smith";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientSelfInfoPatch(
                expectedFirstName, expectedLastName, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedFirstName, responseModel.Model.FirstName);
                Assert.AreEqual(expectedLastName, responseModel.Model.LastName);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserFirstNameApiTest()
        {
            var expectedFirstName = "Sunny";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientSelfInfoPatch(
                expectedFirstName, createdUser.User.LastName, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedFirstName, responseModel.Model.FirstName);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserLastNameApiTest()
        {
            var expectedLastName = "Smith";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientSelfInfoPatch(
                createdUser.User.FirstName, expectedLastName, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedLastName, responseModel.Model.LastName);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }
    }
}
