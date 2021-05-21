using System.Net;
using System.Threading;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;

namespace NewBookModelsApiTests.ApiTests.AccountSettings.AccountInfo
{
    class ChangePasswordApiTests
    {
        [Test]
        public void ChangecsdUserPasswordWithValidDataApiTest()
        {
            var expectedNewPassword = "!@#456QWErty";
            Thread.Sleep(100);
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientPasswordPost(
                "QWE123qwe!@#", expectedNewPassword, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(createdUser.TokenData.Token, responseModel.Model.Token);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }

        [Test]
        public void ChangecsdUserPasswordWithInvalidCurrentPasswordApiTest()
        {
            var expectedNewPassword = "!@#456QWErty";
            Thread.Sleep(100);
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var responseModel = ClientRequests.SendRequestChangeClientPasswordPost(
                "QWE123qwe!@#222", expectedNewPassword, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.IsNull(responseModel.Model.Token);
                Assert.AreEqual(HttpStatusCode.BadRequest, responseModel.Response.StatusCode);
            });
        }
    }
}
