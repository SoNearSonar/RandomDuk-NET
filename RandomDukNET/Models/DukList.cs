using Newtonsoft.Json;

namespace RandomDukNET.Models
{
    public class DukList
    {
        [JsonProperty(PropertyName = "images")]
        public List<string>? ImageFilenames { get; set; }

        [JsonProperty(PropertyName = "gifs")]
        public List<string>? GifFilenames { get; set; }

        [JsonProperty(PropertyName = "http")]
        public List<string>? HttpDuckFilenames { get; set; }

        [JsonProperty(PropertyName = "image_count")]
        public int? ImageCount { get; set; }

        [JsonProperty(PropertyName = "gif_count")]
        public int? GifCount { get; set; }
    }
}
