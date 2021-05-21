﻿using System;
using System.Collections.Generic;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NewBookModelsApiTests.Models.Image;
using Newtonsoft.Json;
using RestSharp;

namespace NewBookModelsApiTests.ApiRequests.Client
{
    class ClientRequests
    {
        public static ResponseModel<ChangeEmailResponse> SendRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return new ResponseModel<ChangeEmailResponse> { Model = changeEmailResponse, Response = response };
        }

        public static IRestResponse SendRequestChangeClientEmailWithInvalidDataPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            return response;
        }

        public static ResponseModel<ChangePhoneNumberResponse> SendRequestChangeClientPhoneNumberPost(string password, string phone, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
            {
                { "password", password },
                { "phone_number", phone },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ChangePhoneNumberResponse>(response.Content);

            return new ResponseModel<ChangePhoneNumberResponse> { Model = changePhoneResponse, Response = response };
        }

        public static ResponseModel<ChangePasswordResponse> SendRequestChangeClientPasswordPost(string oldPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", oldPassword },
                { "new_password", newPassword },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return new ResponseModel<ChangePasswordResponse> { Model = changePasswordResponse, Response = response };
        }

        public static ResponseModel<ChangeSelfInfoResponse> SendRequestChangeClientSelfInfoPatch(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var changeSelfInfoModel = new Dictionary<string, string>
            {
                { "first_name", firstName },
                { "last_name", lastName },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(changeSelfInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeSelfInfoResponse = JsonConvert.DeserializeObject<ChangeSelfInfoResponse>(response.Content);

            return new ResponseModel<ChangeSelfInfoResponse> { Model = changeSelfInfoResponse, Response = response };
        }

        public static ResponseModel<ChangeProfileInfoResponse> SendRequestChangeClientProfileInfoPatch(string industry, string locationName, string locationTimezone, string token)
        {
            var client = new RestClient(" https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var changeProfileInfoModel = new Dictionary<string, string>
            {
                { "industry", industry },
                { "location_name", locationName },
                { "location_timezone", locationTimezone },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(changeProfileInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePriofileInfoResponse = JsonConvert.DeserializeObject<ChangeProfileInfoResponse>(response.Content);

            return new ResponseModel<ChangeProfileInfoResponse> { Model = changePriofileInfoResponse, Response = response };
        }

        public static ClientAuthModel SendRequestClientProfileCompanyInfoPatch(ClientAuthModel clientAuthModel)
        {
            var client = new RestClient(" https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var changeProfileCompanyInfoModel = new Dictionary<string, string>
            {
                { "company_description", "Something" },
                { "company_name", "Company" },
                { "company_website", "http://companyComassasapany.com" },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", clientAuthModel.TokenData.Token);
            request.AddJsonBody(changeProfileCompanyInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            return clientAuthModel;
        }

        public static ResponseModel<ChangeCompanyInfoResponse> SendRequestChangeClientProfileCompanyInfoPatch(string companyDescription, string companyName, string companyWebsite, string token)
        {
            var client = new RestClient(" https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var changeProfileCompanyInfoModel = new Dictionary<string, string>
            {
                { "company_description", companyDescription },
                { "company_name", companyName },
                { "company_website", companyWebsite },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(changeProfileCompanyInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePriofileCompanyInfoResponse = JsonConvert.DeserializeObject<ChangeCompanyInfoResponse>(response.Content);

            return new ResponseModel<ChangeCompanyInfoResponse> { Model = changePriofileCompanyInfoResponse, Response = response };
        }

        public static ResponseModel<AvatarImageResponse> SendRequestUploadClientProfileImagePatch(string token, string avatarId)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);

            request.AddHeader("authorization", token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("avatar_id", avatarId);

            var response = client.Execute(request);
            var avatarResponse = JsonConvert.DeserializeObject<AvatarImageResponse>(response.Content);

            return new ResponseModel<AvatarImageResponse> { Model = avatarResponse, Response = response };
        }

        public static string SendReguestUploadClientImagesPost(string token, string fileName, string imagePath)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("authorization", token);
            request.AddHeader("content-disposition", $"form-data; name='file'; filename='{fileName}'");
            request.AddFile("file", $"{imagePath}");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var image = JsonConvert.DeserializeObject<ImageModel>(response.Content);

            return image.Image.Id;
        }
    }

    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public IRestResponse Response { get; set; }
    }
}
