using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using RestSharp;
namespace NewBookModelsApiTests.ApiTests.AccountSettings.AccountInfo
{
    class ChangePhoneApiTests
    {
        [Test]
        public void ChangeUserPhoneApiTest()
        {
            var expectedPhone = $"5556664452";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientPhoneNumberPost(
                "QWE123qwe!@#", expectedPhone, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedPhone, responseModel.Model.PhoneNumber);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserPhoneWithInvalidCurrentPasswordApiTest()
        {
            var expectedPhone = $"5556664452";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientPhoneNumberPost(
                "QWE123qwe!@#221", expectedPhone, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.IsNull(responseModel.Model.PhoneNumber);
                Assert.AreEqual(HttpStatusCode.BadRequest, responseModel.Response.StatusCode);
            });
        }
    }
}
