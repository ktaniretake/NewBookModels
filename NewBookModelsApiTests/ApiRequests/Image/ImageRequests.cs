using NewBookModelsApiTests.Models.Image;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBookModelsApiTests.ApiRequests.Image
{
    class ImageRequests
    {
        public static ImageModel SendRequestUploadImagePost(string token, string pathstring)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");
            var request = new RestRequest(Method.OPTIONS);

            //request.AddHeader("Content-Disposition", "form-data; name="file"; filename = $"{ filename} ");
            //request.AddHeader("Content-Type", "image/jpeg");
            //request.AddFile("file", "C:/Users/koguno/Desktop/ae86.jpg");

            //request.AddHeader("content-type", "application/json");
            //request.AddHeader("authorization", token);

            //request.AddFile("file", binary);
            //request.AddJsonBody(newLocationModel);
            //request.DateFormat();

            request.AddHeader("authorization", token);
            request.AddHeader("content - type", "multipart/form-data; boundary =----WebKitFormBoundaryJGYXJVPo1EbwkMAn");
            request.AddHeader($"Content-Disposition", "form-data; name=file; filename= {filename}");
            request.AddHeader("Content-Type", "image/jpeg");
            request.AddFile("file", pathstring);
            request.RequestFormat = DataFormat.Json;



            //request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var uploadedImage = JsonConvert.DeserializeObject<ImageModel>(response.Content);

            return uploadedImage;
        }
    }
}
