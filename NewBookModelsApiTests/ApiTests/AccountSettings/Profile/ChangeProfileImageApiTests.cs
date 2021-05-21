using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using System.Net;


namespace NewBookModelsApiTests.ApiTests.AccountSettings.Profile
{
    class ChangeProfileImageApiTests
    {
        [Test]
        public void ChangeUserProfileImageApiTest()
        {
            var fileName = "123.jpg";
            var filePath = "C:/Users/hydra/Downloads/123.jpg";
            var user = new UserConstructor();
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user.User);

            var imageId = ClientRequests.SendReguestUploadClientImagesPost(createdUser.TokenData.Token, fileName, filePath);
            var responseModel = ClientRequests.SendRequestUploadClientProfileImagePatch(createdUser.TokenData.Token, imageId);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(imageId, responseModel.Model.Avatar.Id);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });
        }
    }
}
