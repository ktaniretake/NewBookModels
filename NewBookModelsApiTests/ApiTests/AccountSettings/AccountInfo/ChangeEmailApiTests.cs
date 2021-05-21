using System;
using System.Net;
using System.Threading;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;

namespace NewBookModelsApiTests
{
    public class ChangeEmailApiTests
    {
        [Test]
        public void ChangeUserEmailWithValidDataApiTest()
        {
            var expectedEmail = $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com";
            Thread.Sleep(100);
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientEmailPost(
                "QWE123qwe!@#", expectedEmail, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEmail, responseModel.Model.Email);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserEmailWithInvalidCurrentPasswordApiTest()
        {
            var expectedEmail = $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com";
            Thread.Sleep(100);
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientEmailPost(
                "QWE123qwe!@#122", expectedEmail, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.IsNull(responseModel.Model.Email);
                Assert.AreEqual(HttpStatusCode.BadRequest, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangeUserEmailWithInvalidEmailApiTest()
        {
            var expectedEmail = $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail";
            Thread.Sleep(100);
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var response = ClientRequests.SendRequestChangeClientEmailWithInvalidDataPost(
                "QWE123qwe!@#", expectedEmail, createdUser.TokenData.Token);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}