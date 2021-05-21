using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    class ChangePasswordResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
