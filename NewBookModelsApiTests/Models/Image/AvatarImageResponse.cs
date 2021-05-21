using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Image
{
    public class AvatarImageResponse
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }
    }
    public class Avatar
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("large")]
        public Large Large { get; set; }

        [JsonProperty("small")]
        public Small Small { get; set; }

        [JsonProperty("medium")]
        public Medium Medium { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("original")]
        public Original Original { get; set; }
    }
}
