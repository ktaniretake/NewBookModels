using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    class ChangeProfileInfoResponse
    {
        [JsonProperty("industry")]
        public string Industry { get; set; }
        [JsonProperty("location_name")]
        public string LocationName { get; set; }
        [JsonProperty("location_timezone")]
        public string LocationTimezone { get; set; }
    }
}
