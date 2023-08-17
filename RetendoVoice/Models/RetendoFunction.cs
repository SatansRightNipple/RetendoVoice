using System.Text.Json.Serialization;

namespace RetendoVoice.Models
{
    public class RetendoFunction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonConstructor]
        public RetendoFunction(string name, string description, List<Parameter> parameters) 
        {
            Name = name;
            Description = description;
            Parameters = parameters;
        }
    }
}