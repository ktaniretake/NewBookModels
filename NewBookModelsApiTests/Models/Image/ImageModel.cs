
using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Image
{
    public class Large
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Small
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Medium
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Original
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Image
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

    public class ImageModel
    {
        [JsonProperty("image")]
        public Image Image { get; set; }
    }

}
