﻿using Newtonsoft.Json;

namespace RandomDukNET.Models
{
    public class Duk
    {
        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string? Url { get; set; }
    }
}
