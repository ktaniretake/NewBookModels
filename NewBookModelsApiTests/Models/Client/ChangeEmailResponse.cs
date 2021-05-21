using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    public class ChangeEmailResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
