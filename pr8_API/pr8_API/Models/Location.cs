using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace pr8_API.Models
{
    public class Location
    {
        public string Key { get; set; }
        [JsonPropertyName("LocalizedName")]
        public string Name { get; set; }
        public Country Country { get; set; }
    }
    public class Country
    {
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        [JsonPropertyName("LocalizedName")]
        public string Name { get; set; }
    }
}
