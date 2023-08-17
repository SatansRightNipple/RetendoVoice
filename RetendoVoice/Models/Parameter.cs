using System.Text.Json.Serialization;

namespace RetendoVoice.Models
{
    public class Parameter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonConstructor]
        public Parameter(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }
    }
}
