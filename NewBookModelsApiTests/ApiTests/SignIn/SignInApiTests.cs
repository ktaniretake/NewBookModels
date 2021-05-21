using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace NewBookModelsApiTests.ApiTests.AccountSettings
{
    class SignInApiTests
    {
        [Test]
        public void SignInWithValidDataApiTest()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com" },
                { "first_name", "Kate" },
                { "last_name", "Jonson" },
                { "password", "QWE123qwe" },
                { "phone_number", "1254785852" }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
